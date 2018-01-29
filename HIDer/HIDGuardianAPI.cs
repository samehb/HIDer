using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.Management;

namespace HIDer
{
    static class HIDGuardianAPI
    {
        public static string GetDevicesList() // Get the list of available devices.
        {
            string devicesstring = "";
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity where DeviceID Like ""HID%""")) // Get only entries where the DID starts with HID
                collection = searcher.Get();

            foreach (var device in collection) // A simple enumeration over the devices needed.
            {
                string devicedesc = device.GetPropertyValue("Description").ToString().ToLower();
                string deviceid = device.GetPropertyValue("DeviceID").ToString();
                deviceid = deviceid.Substring(0, deviceid.LastIndexOf("\\"));
                if (device["Status"].ToString() == "OK")
                {
                    if (devicedesc.Contains("game")) // Simple detection at the moment.
                        devicesstring += GetOEMName(deviceid) + ":"; // Get joystick names from the registry
                    else if (devicedesc.Contains("mouse"))
                        devicesstring += "USB Optical Mouse:";
                    else if (devicedesc.Contains("keyboard"))
                        devicesstring += "USB Keyboard:";
                    else
                        devicesstring += device.GetPropertyValue("Description");
                    devicesstring += deviceid + ";";
                }
            }

            collection.Dispose();
            return devicesstring;
        }

        private static string GetOEMName(string devid) // Used by GetDevicesList to get OEM names for joysticks from registry
        {
            string oemname = "Unknown";
            string hid = devid.Contains("&COL") ? devid.Substring(0, devid.LastIndexOf("&COL")).Replace(@"HID\", "") : devid.Replace(@"HID\", ""); // Change the hid value to match the registry values. Remove HID\ and &COL if it is available.
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\MediaProperties\PrivateProperties\Joystick\OEM\" + hid))
            {
                if (key != null)
                    oemname = key.GetValue("OEMName").ToString();
            }
            return oemname;
        }

        public static string GetAffectedDevicesList() // Get the list of hidden devices.
        {
            string hids = "";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters"))
            {
                if (key != null)
                {
                    foreach (string device in (string[])key.GetValue("AffectedDevices"))
                    {
                        hids += device + ";";
                    }
                }
            }
            return hids.TrimEnd(';');
        }

        public static string GetWhitelistedProcessesList() // Get the list of allowed processes pids.
        {
            string processes = "";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters\Whitelist"))
            {
                if (key != null)
                {
                    foreach (string process in key.GetSubKeyNames())
                    {
                        processes += process + ";";
                    }
                }
            }
            return processes.TrimEnd(';');
        }

        public static bool HideDevice(string hid) // Hide a device based on HID.
        {
            string hidsstring = "";
            List<string> hidslist = new List<string>();
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters", true))
            {
                if (key != null)
                {
                    foreach (string device in (string[])key.GetValue("AffectedDevices")) // Iterate over the registry string[] value then add all values to a string to check against the hid argument.
                    {
                        hidsstring += device + ";";
                        hidslist.Add(device); // Cache the values for use on the following block.
                    }

                    if (!hidsstring.Contains(hid + ";")) // If the hid value is not added, add it and change the registry value.
                    {
                        hidslist.Add(hid);
                        key.SetValue("AffectedDevices", hidslist.ToArray());
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UnhideDevice(string hid) // Unhide a device based on HID.
        {
            bool removed = false;
            List<string> hidslist = new List<string>();
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters", true))
            {
                if (key != null)
                {
                    foreach (string device in (string[])key.GetValue("AffectedDevices")) // Iterate over the hids and if the argument hid matches any of the registry values, do not add it to the list, then change the removed value to reflect this.
                    {
                        if (device != hid)
                            hidslist.Add(device);
                        else
                            removed = true;
                    }

                    if (removed) // The hid was removed? Change the registry value.
                    {
                        key.SetValue("AffectedDevices", hidslist.ToArray());
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool UnhideAllDevices() // Unhide all devices.
        {
            List<string> hidslist = new List<string>();
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters", true))
            {
                if (key != null)
                {
                    key.SetValue("AffectedDevices", new string[] { });
                    return true;
                }
            }
            return false;
        }

        public static bool AddWhitelistedProcess(string pid) // Add process to the allowed whitelist.
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters\Whitelist", true))
            {
                if (key != null)
                {
                    key.CreateSubKey(pid);
                    return true;
                }
            }
            return false;
        }

        public static bool RemoveWhitelistedProcess(string pid) // Remove a process from the allowed whitelist.
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters\Whitelist", true))
            {
                if (key != null)
                {
                    key.DeleteSubKey(pid, false);
                    return true;
                }
            }
            return false;
        }

        public static bool RemoveAllWhitelistedProcesses() // Remove all allowed processes from the whitelist.
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\HidGuardian\Parameters\Whitelist", true))
            {
                if (key != null)
                {
                    foreach (string process in key.GetSubKeyNames())
                    {
                        key.DeleteSubKey(process, false);
                    }
                    return true;
                }
            }
            return false;
        }

        private static string StartProcess(string processname, string args)
        {
            Process proc = new Process { StartInfo = new ProcessStartInfo { FileName = processname, Arguments = args, UseShellExecute = false, RedirectStandardOutput = true, CreateNoWindow = true } };
            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }

        public static void ReplugHID(string hid) // Replug a device so the user does not have to restart the pc or disconnect/reconnect.
        {
            StartProcess(@"res\devcon.exe", "disable" + " " + "\"" + hid + "\"");
            Thread.Sleep(500);
            StartProcess(@"res\devcon.exe", "enable" + " " + "\"" + hid + "\"");
        }

        public static bool IsViGEmBusInstalled()
        {
            string result = StartProcess(@"res\devcon.exe", @"Status Root\ViGEmBus");
            if (result.Contains("matching device(s) found"))
                return true;
            return false;
        }

        public static bool IsHidGuardianInstalled()
        {
            string result = StartProcess(@"res\devcon.exe", @"Status Root\HidGuardian");
            if (result.Contains("matching device(s) found"))
                return true;
            return false;
        }

        public static bool IsHidCerberusInstalled()
        {
            string result = StartProcess("sc", @"query Hidcerberus.Srv");
            if (!result.Contains("service does not exist"))
                return true;
            return false;
        }

        public static bool IsHidCerberusRunning()
        {
            string result = StartProcess("sc", @"query Hidcerberus.Srv");
            if (result.Contains("RUNNING") || result.Contains("START_PENDING"))
                return true;
            return false;
        }

        public static bool InstallViGEm()
        {
            string id = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            string TESTER = StartProcess(@"res\devcon.exe", @"install res\ViGEmBus\" + id + @"\ViGEmBus.inf Root\ViGEmBus");
            if (IsViGEmBusInstalled())
                return true;
            return false;
        }

        public static bool UninstallViGEm()
        {
            string TESTER = StartProcess(@"res\devcon.exe", @"remove Root\ViGEmBus");
            if (!IsViGEmBusInstalled())
                return true;
            return false;
        }

        public static bool InstallHidGuardian()
        {
            string id = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            string TESTER = StartProcess(@"res\devcon.exe", @"install res\HidGuardian\" + id + @"\HidGuardian.inf Root\HidGuardian");
            string TESTER2 = StartProcess(@"res\devcon.exe", @"classfilter HIDClass upper -HidGuardian");
            if (IsHidGuardianInstalled())
                return true;
            return false;
        }

        public static bool UninstallHidGuardian()
        {
            string TESTER = StartProcess(@"res\devcon.exe", @"remove Root\HidGuardian");
            string TESTER2 = StartProcess(@"res\devcon.exe", @"classfilter HIDClass upper !HidGuardian");
            if (!IsHidGuardianInstalled())
                return true;
            return false;
        }

        public static bool InstallHidCerberus()
        {
            string TESTER = StartProcess(@"res\HidCerberus\HidCerberus.Srv.exe", "install");
            if (IsHidCerberusInstalled())
                return true;
            return false;
        }

        public static bool UninstallHidCerberus()
        {
            string TESTER = StartProcess(@"res\HidCerberus\HidCerberus.Srv.exe", "uninstall");
            if (!IsHidCerberusInstalled())
                return true;
            return false;
        }

        public static bool StartHidCerberus()
        {
            string TESTER = StartProcess("sc", "start Hidcerberus.Srv");
            if (IsHidCerberusRunning())
                return true;
            return false;
        }

        public static bool StopHidCerberus()
        {
            string TESTER = StartProcess("sc", "stop Hidcerberus.Srv");
            if (!IsHidCerberusRunning())
                return true;
            return false;
        }

        public static bool IsHidCerberusAvailable(string path)
        {
            if(File.Exists(path + @"\res\HidCerberus\HidCerberus.Srv.exe"))
                return true;
            return false;
        }
    }
}
