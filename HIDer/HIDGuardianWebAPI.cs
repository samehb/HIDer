using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;

namespace HIDer
{
    // This class utilizes the already available HidGuardian Web Api (HidCerberus) (http://localhost:26762)
    static class HIDGuardianWebAPI
    {
        public static string GetDevicesList() // Get the list of available devices.
        {
            string deviceslist = "";
            try
            {
                using (var client = new WebClient())
                {
                    string devicesjson = client.DownloadString("http://localhost:26762/api/v1/hid/devices/get");
                    List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(devicesjson);
                    foreach (Device device in devices)
                    {
                        deviceslist += device.productName + ":" + device.hardwareId + ";";
                    }
                    return deviceslist;
                }
            }
            catch
            {

            }
            return "";
        }

        public static string GetAffectedDevicesList() // Get the list of hidden devices.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string affecteddevices = client.DownloadString("http://localhost:26762/api/v1/hidguardian/affected/get").Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\\\\", "\\").Replace(",", ";");
                    if (affecteddevices != "")
                        return affecteddevices;
                }
            }
            catch
            {

            }
            return "";
        }

        public static string GetWhitelistedProcessesList() // Get the list of allowed processes pids.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string whitelistedprocesses = client.DownloadString("http://localhost:26762/api/v1/hidguardian/whitelist/get").Replace("[", "").Replace("]", "").Replace(",", ";");
                    if (whitelistedprocesses != "")
                        return whitelistedprocesses;
                }
            }
            catch
            {

            }
            return "";
        }

        public static bool HideDevice(string hid) // Hide a device based on HID.
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string removed = client.UploadString("http://localhost:26762/api/v1/hidguardian/affected/add", "hwids=" + hid);
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public static bool UnhideDevice(string hid) // Unhide a device based on HID.
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string removed = client.UploadString("http://localhost:26762/api/v1/hidguardian/affected/remove", "hwids=" + hid);
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch (Exception ex)
            {
                string ddd = ex.ToString();
            }
            return false;
        }

        public static bool UnhideAllDevices() // Unhide all devices.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string removed = client.DownloadString("http://localhost:26762/api/v1/hidguardian/affected/purge");
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public static bool AddWhitelistedProcess(string pid) // Add process to the allowed whitelist.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string removed = client.DownloadString("http://localhost:26762/api/v1/hidguardian/whitelist/add/" + pid);
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public static bool RemoveWhitelistedProcess(string pid) // Remove a process from the allowed whitelist.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string removed = client.DownloadString("http://localhost:26762/api/v1/hidguardian/whitelist/remove/" + pid);
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch
            {

            }
            return false;
        }

        public static bool RemoveAllWhitelistedProcesses() // Remove all allowed processes from the whitelist.
        {
            try
            {
                using (var client = new WebClient())
                {
                    string removed = client.DownloadString("http://localhost:26762/api/v1/hidguardian/whitelist/purge");
                    if (removed.Contains("OK"))
                        return true;
                }
            }
            catch
            {

            }
            return false;
        }

        private static string StartProcess(string processname, string args, bool shell)
        {
            Process proc = new Process { StartInfo = new ProcessStartInfo { FileName = processname, Arguments = args, UseShellExecute = shell, RedirectStandardOutput = true, CreateNoWindow = true } };
            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }

        public static void ReplugHID(string hid) // Replug a device so the user does not have to restart the pc or disconnect/reconnect.
        {
            StartProcess(@"res\devcon.exe", "disable" + " " + "\"" + hid + "\"", false);
            Thread.Sleep(500);
            StartProcess(@"res\devcon.exe", "enable" + " " + "\"" + hid + "\"", false);
        }

        public static bool IsViGEmBusInstalled()
        {
            string result = StartProcess(@"res\devcon.exe", @"Status Root\ViGEmBus", false);
            if (result.Contains("matching device(s) found"))
                return true;
            return false;
        }

        public static bool IsHidGuardianInstalled()
        {
            string result = StartProcess(@"res\devcon.exe", @"Status Root\HidGuardian", false);
            if (result.Contains("matching device(s) found"))
                return true;
            return false;
        }

        public static bool IsHidCerberusInstalled()
        {
            string result = StartProcess("sc", @"query Hidcerberus.Srv", false);
            if (!result.Contains("service does not exist"))
                return true;
            return false;
        }

        public static bool IsHidCerberusRunning()
        {
            string result = StartProcess("sc", @"query Hidcerberus.Srv", false);
            if (result.Contains("RUNNING") || result.Contains("START_PENDING"))
                return true;
            return false;
        }

        public static bool InstallViGEm()
        {
            string id = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            string TESTER = StartProcess(@"res\devcon.exe", @"install res\ViGEmBus\" + id + @"\ViGEmBus.inf Root\ViGEmBus", false);
            if (IsViGEmBusInstalled())
                return true;
            return false;
        }

        public static bool UninstallViGEm()
        {
            string TESTER = StartProcess(@"res\devcon.exe", @"remove Root\ViGEmBus", false);
            if (!IsViGEmBusInstalled())
                return true;
            return false;
        }

        public static bool InstallHidGuardian()
        {
            string id = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            string TESTER = StartProcess(@"res\devcon.exe", @"install res\HidGuardian\" + id + @"\HidGuardian.inf Root\HidGuardian", false);
            string TESTER2 = StartProcess(@"res\devcon.exe", @"classfilter HIDClass upper -HidGuardian", false);
            if (IsHidGuardianInstalled())
                return true;
            return false;
        }

        public static bool UninstallHidGuardian()
        {
            string TESTER = StartProcess(@"res\devcon.exe", @"remove Root\HidGuardian", false);
            string TESTER2 = StartProcess(@"res\devcon.exe", @"classfilter HIDClass upper !HidGuardian", false);
            if (!IsHidGuardianInstalled())
                return true;
            return false;
        }

        public static bool InstallHidCerberus()
        {
            string TESTER = StartProcess(@"res\HidCerberus\HidCerberus.Srv.exe", "install", false);
            if (IsHidCerberusInstalled())
                return true;
            return false;
        }

        public static bool UninstallHidCerberus()
        {
            string TESTER = StartProcess(@"res\HidCerberus\HidCerberus.Srv.exe", "uninstall", false);
            if (!IsHidCerberusInstalled())
                return true;
            return false;
        }

        public static bool StartHidCerberus()
        {
            string TESTER = StartProcess("sc", "start Hidcerberus.Srv", false);
            if (IsHidCerberusRunning())
                return true;
            return false;
        }

        public static bool StopHidCerberus()
        {
            string TESTER = StartProcess("sc", "stop Hidcerberus.Srv", false);
            if (!IsHidCerberusRunning())
                return true;
            return false;
        }

        public static bool IsHidCerberusAvailable(string path)
        {
            if (File.Exists(path + @"\res\HidCerberus\HidCerberus.Srv.exe"))
                return true;
            return false;
        }
    }

    class Device // The class that represents the json data from api/v1/hid/devices/get
    {
        public string manufacturer { get; set; }
        public string productName { get; set; }
        public string devicePath { get; set; }
        public string hardwareId { get; set; }
    }
}
