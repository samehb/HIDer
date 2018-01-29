using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace HIDer
{
    public partial class MainForm : Form
    {
        string AffectedDevices = "";
        bool DevConAvailable = false; // This is used because CheckDevCon is used again on application exit.

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            if (Directory.Exists(path + @"\update") && !IsDirectoryEmpty(path + @"\update")) // This is used to make it easier for the user to install the external resources required for the project.
            {
                ProcessUpdates(path);
            }

            DevConAvailable = CheckDevCon();

            if (DevConAvailable) // Check if devcon is available. Close the application if it is not.
            {
                LoadSettings();
                CheckExternalResources(); 

                // if (HIDGuardianAPI.IsWebsiteAvailable()) // Check if the website is available. If it is not, do not proceed. HidGuardianWebAPI only.

                HIDGuardianAPI.RemoveAllWhitelistedProcesses(); // Remove all processes from last run in case the user crashed the application.
                HIDGuardianAPI.AddWhitelistedProcess(Process.GetCurrentProcess().Id.ToString()); // This is probably not necessary. Check later.

                UnhideDevices(); // In case the user crashed the application instead of closing it.
                HandleProcesses(); // Deal with available processes and add whitelisted processes based on the stored settings (settings.ini file). HandleProcesses is called before HandleDevices because HandleDevices refreshes (replugs) the hidden devices making them available for the whitelisted processes from this step.
                HandleDevices();  // Add available and hidden devices from previous time, that the application stored in the file (settings.ini). All hidden devices are stored on application exit.
            }
            else
                DisplayMissing();
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private bool CheckDevCon()
        {
            string path = Application.StartupPath;
            if (File.Exists(path + @"\res\devcon.exe"))
                return true;
            return false;
        }

        private void DisplayMissing()
        {
            DialogResult result = MessageBox.Show("Devcon.exe is missing from the res folder, follow the guide and try again.", "Missing Devcon!", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void ProcessUpdates(string path)
        {
            foreach (string file in Directory.GetFiles(path + @"\update")) // The application iterates over the available file and checks for vigembus, hidguardian, and archived devcon files then deals with them.
            {
                string filelwr = Path.GetFileName(file).ToLower();
                if (filelwr.StartsWith("vigembus") && filelwr.EndsWith(".zip"))
                {
                    if(Directory.Exists(path + @"\res\ViGEmBus")) // Get rid of old files.
                        Directory.Delete(path + @"\res\ViGEmBus", true);

                    Directory.CreateDirectory(path + @"\res\ViGEmBus");

                    ZipFile.ExtractToDirectory(path + @"\update\" + filelwr, path + @"\res\ViGEmBus"); // Extract the archive into the res folder.
                }
                else if (filelwr.StartsWith("hidguardian") && filelwr.EndsWith(".zip"))
                {
                    if (Directory.Exists(path + @"\res\HidGuardian")) // Get rid of old files.
                        Directory.Delete(path + @"\res\HidGuardian", true);

                    Directory.CreateDirectory(path + @"\res\HidGuardian");

                    ZipFile.ExtractToDirectory(path + @"\update\" + filelwr, path + @"\res\HidGuardian");
                }
                else if (filelwr == "82c1721cd310c73968861674ffc209c9.cab" && !Environment.Is64BitOperatingSystem) // Devcon cab archive for 32-bit systems.
                {
                    if (File.Exists(path + @"\res\devcon.exe"))
                        File.Delete(path + @"\res\devcon.exe");
                    StartProcess(@"expand", "-f:fil5a9177f816435063f779ebbbd2c1a1d2 update\\82c1721cd310c73968861674ffc209c9.cab " + "\"" + path + @"\res" + "\""); // Extract only the devcon file then rename it.
                    if(File.Exists(path + @"\res\fil5a9177f816435063f779ebbbd2c1a1d2"))
                    {
                        File.Move(path + @"\res\fil5a9177f816435063f779ebbbd2c1a1d2", path + @"\res\devcon.exe");
                    }
                }
                else if (filelwr == "787bee96dbd26371076b37b13c405890.cab" && Environment.Is64BitOperatingSystem) // Devcon cab archive for 64-bit systems.
                {
                    if (File.Exists(path + @"\res\devcon.exe"))
                        File.Delete(path + @"\res\devcon.exe");
                    StartProcess(@"expand", "-f:filbad6e2cce5ebc45a401e19c613d0a28f update\\787bee96dbd26371076b37b13c405890.cab " + "\"" + path + @"\res" + "\"");
                    if (File.Exists(path + @"\res\filbad6e2cce5ebc45a401e19c613d0a28f"))
                    {
                        File.Move(path + @"\res\filbad6e2cce5ebc45a401e19c613d0a28f", path + @"\res\devcon.exe");
                    }
                }
                File.Delete(file);
            }
            Directory.Delete(path + @"\update");
        }

        private string StartProcess(string processname, string args)
        {
            Process proc = new Process { StartInfo = new ProcessStartInfo { FileName = processname, Arguments = args, UseShellExecute = false, RedirectStandardOutput = true, CreateNoWindow = true } };
            proc.Start();
            return proc.StandardOutput.ReadToEnd();
        }

        private void UnhideDevices()
        {
            string prevaffecteddevices = HIDGuardianAPI.GetAffectedDevicesList(); // Get a list of available hidden devices from last run.

            foreach (string prevaffecteddevice in prevaffecteddevices.Split(';'))
            {
                HIDGuardianAPI.UnhideDevice(prevaffecteddevice);
                HIDGuardianAPI.ReplugHID(prevaffecteddevice); // Iterate over the list of affected devices from the last run and replug them (to refresh them).
            }
        }

        private void HandleDevices() // Add available and hidden devices from previous time, that the application stored in the file (settings.ini). All hidden devices are stored on application exit.
        {
            string devices = HIDGuardianAPI.GetDevicesList().TrimEnd(';');

            if (AffectedDevices != "") // Add affected hidden devices from last time acquired from the settings.ini
            {
                foreach (string affecteddevice in AffectedDevices.Split(';'))
                {
                    if (affecteddevice.Contains(":"))
                    {
                        HIDGuardianAPI.HideDevice(affecteddevice.Split(':')[1]);
                        HIDGuardianAPI.ReplugHID(affecteddevice.Split(':')[1]);
                        HiddenDevicesListBox.Items.Add(affecteddevice);
                    }
                }
            }

            if (devices != "") // Add all (available) devices excluding the ones from the last segment.
            {
                foreach (string device in devices.Split(';'))
                {
                    if (!AffectedDevices.Contains(device))
                        AvailableDevicesListBox.Items.Add(device);
                }
            }
        }

        private void HandleProcesses()
        {
            foreach (Process process in Process.GetProcesses()) // Iterate over the list of available processes skipping this program, system, and idle processes.
            {
                if (!process.ProcessName.Contains("HIDer") && process.ProcessName != "System" && process.ProcessName != "Idle")
                {
                    string whitelistedprocesses  = PermenantProccessesTextBox.Text;
                    if (whitelistedprocesses != "" && whitelistedprocesses.Contains(process.ProcessName + ";")) // If the current process name matches one from permenant proccesses (PermenantProccessesTextBox.Text), it is added to the HidGuardian whitelist.
                    {
                        HIDGuardianAPI.AddWhitelistedProcess(process.Id.ToString());
                        AllowedProcessesListBox.Items.Add(process.ProcessName + ":" + process.Id);
                    }
                    else
                        DeniedProcessesListBox.Items.Add(process.ProcessName + ":" + process.Id); // Everything else goes in here.
                }
            }
        }

        private void HideDeviceBtn_Click(object sender, EventArgs e)
        {
            if (AvailableDevicesListBox.SelectedIndex != -1)
            {
                string hid = AvailableDevicesListBox.SelectedItem.ToString().Split(':')[1];
                HIDGuardianAPI.HideDevice(hid);
                MoveSelectedListBoxItem(AvailableDevicesListBox, HiddenDevicesListBox);
                HIDGuardianAPI.ReplugHID(hid); // ReplugHID is used to fresh the devices so the user does not have to restart or unplug/replug the devices.
            }
        }

        private void UnhideDeviceBtn_Click(object sender, EventArgs e)
        {
            if (HiddenDevicesListBox.SelectedIndex != -1)
            {
                string hid = HiddenDevicesListBox.SelectedItem.ToString().Split(':')[1];
                HIDGuardianAPI.UnhideDevice(hid);
                MoveSelectedListBoxItem(HiddenDevicesListBox, AvailableDevicesListBox);
                HIDGuardianAPI.ReplugHID(hid);
            }
        }

        private void AllowProcessBtn_Click(object sender, EventArgs e)
        {
            if (DeniedProcessesListBox.SelectedIndex != -1)
            {
                HIDGuardianAPI.AddWhitelistedProcess(DeniedProcessesListBox.SelectedItem.ToString().Split(':')[1]);
                MoveSelectedListBoxItem(DeniedProcessesListBox, AllowedProcessesListBox);
            }
        }

        private void DenyProcessBtn_Click(object sender, EventArgs e)
        {
            if (AllowedProcessesListBox.SelectedIndex != -1)
            {
                HIDGuardianAPI.RemoveWhitelistedProcess(AllowedProcessesListBox.SelectedItem.ToString().Split(':')[1]);
                MoveSelectedListBoxItem(AllowedProcessesListBox, DeniedProcessesListBox);
            }
        }

        private void RefreshProcessesBtn_Click(object sender, EventArgs e) // Refresh the processes lists both of them.
        {
            ListBox TempLB = new ListBox();
            DeniedProcessesListBox.Items.Clear();

            HIDGuardianAPI.RemoveAllWhitelistedProcesses(); // Remove all added processes and then add HIDer's pid.
            HIDGuardianAPI.AddWhitelistedProcess(Process.GetCurrentProcess().Id.ToString());

            foreach (Process process in Process.GetProcesses()) // Iterate over processes and check if the refreshed processes are not available in the allowed listbox, if they are not, add them to the main list. If they are, add them to a temp list then refresh the allowed whitelist listbox with the temp list. This is used because some processes added to the allowed list might have been terminated, so they need to be removed.
            {
                if (!process.ProcessName.Contains("HIDer") && process.ProcessName != "System" && process.ProcessName != "Idle")
                {
                    if (AllowedProcessesListBox.FindStringExact(process.ProcessName + ":" + process.Id) == -1)
                        DeniedProcessesListBox.Items.Add(process.ProcessName + ":" + process.Id);
                    else
                    {
                        HIDGuardianAPI.AddWhitelistedProcess(process.Id.ToString()); // Re-add the removed processes.
                        TempLB.Items.Add(process.ProcessName + ":" + process.Id);
                    }
                }
            }

            AllowedProcessesListBox.Items.Clear();
            if (TempLB.Items.Count > 0)
            {
                MoveListBoxItems(TempLB, AllowedProcessesListBox);
            }
        }

        private void UnhideAllBtn_Click(object sender, EventArgs e)
        {
            HIDGuardianAPI.UnhideAllDevices();
            foreach (var device in HiddenDevicesListBox.Items)
            {
                string hid = device.ToString().Split(':')[1];
                HIDGuardianAPI.UnhideDevice(hid);
                HIDGuardianAPI.ReplugHID(hid);
            }
            MoveListBoxItems(HiddenDevicesListBox, AvailableDevicesListBox);
        }

        private void DenyAllProcessBtn_Click(object sender, EventArgs e)
        {
            HIDGuardianAPI.RemoveAllWhitelistedProcesses();
            HIDGuardianAPI.AddWhitelistedProcess(Process.GetCurrentProcess().Id.ToString());
            MoveListBoxItems(AllowedProcessesListBox, DeniedProcessesListBox);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // On exit
        {
            if (DevConAvailable)
            {
                string devices = "";
                string processes = "";
                HIDGuardianAPI.RemoveAllWhitelistedProcesses(); // Remove all added processes.
                UnhideDevices(); // Remove and unhide hidden devices.
                foreach (var device in HiddenDevicesListBox.Items) // Store the settings.
                {
                    devices += device.ToString() + ";";
                }
                foreach (var process in PermenantProccessesTextBox.Text.TrimEnd(';').Split(';'))
                {
                    processes += process + ";";
                }
                File.WriteAllText("settings.ini", "devices=" + devices + "\r\n" + "processes=" + processes);
            }
        }

        private void InstallViGEmBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.InstallViGEm())
            {
                InstallViGEmBtn.Enabled = false;
                UninstallViGEmBtn.Enabled = true;
            }
        }

        private void InstallHidGuardianBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.InstallHidGuardian())
            {
                InstallHidGuardianBtn.Enabled = false;
                UninstallHidGuardianBtn.Enabled = true;
            }
        }

        private void InstallHidCerberusBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.InstallHidCerberus())
            {
                InstallHidCerberusBtn.Enabled = false;
                UninstallHidCerberusBtn.Enabled = true;
                StartHidCerberusBtn.Enabled = true;
                StopHidCerberusBtn.Enabled = false;
            }
        }

        private void StartHidCerberusBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.StartHidCerberus())
            {
                StartHidCerberusBtn.Enabled = false;
                StopHidCerberusBtn.Enabled = true;
            }
        }

        private void StopHidCerberusBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.StopHidCerberus())
            {
                StartHidCerberusBtn.Enabled = true;
                StopHidCerberusBtn.Enabled = false;
            }
        }

        private void UninstallViGEmBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.UninstallViGEm())
            {
                InstallViGEmBtn.Enabled = true;
                UninstallViGEmBtn.Enabled = false;
            }
        }

        private void UninstallHidGuardianBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.UninstallHidGuardian())
            {
                InstallHidGuardianBtn.Enabled = true;
                UninstallHidGuardianBtn.Enabled = false;
            }
        }

        private void UninstallHidCerberusBtn_Click(object sender, EventArgs e)
        {
            if (HIDGuardianAPI.UninstallHidCerberus())
            {
                InstallHidCerberusBtn.Enabled = true;
                UninstallHidCerberusBtn.Enabled = false;
                StartHidCerberusBtn.Enabled = false;
                StopHidCerberusBtn.Enabled = false;
            }
        }

        private void MoveSelectedListBoxItem(ListBox source, ListBox destination)
        {
            if (source.SelectedIndex != -1)
            {
                destination.Items.Add(source.SelectedItem);
                source.Items.Remove(source.SelectedItem);
            }
        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            object[] objCollection = new object[source.Items.Count];
            source.Items.CopyTo(objCollection, 0);
            destination.Items.AddRange(objCollection);
            source.Items.Clear();
        }

        private void LoadSettings() // Load settings on start.
        {
            string path = Application.StartupPath;
            String[] settings = File.Exists(path + "\\settings.ini") ? File.ReadAllText(path + "\\settings.ini").Split(new[] { Environment.NewLine }, StringSplitOptions.None) : null;

            if (settings != null && settings.Length == 2)
            {
                AffectedDevices = settings[0].Replace("devices=", "").TrimEnd(';');
                if (settings[1] != "processes=")
                    PermenantProccessesTextBox.Text = settings[1].EndsWith(";") ? settings[1].Replace("processes=", "").Replace(".exe", "") : settings[1].Replace("processes=", "").Replace(".exe", "") + ";";
            }
        }

        private void CheckExternalResources() // Used to check what is installed/available and what is not to handle the disabling/hiding of controls.
        {
            if (HIDGuardianAPI.IsViGEmBusInstalled())
                InstallViGEmBtn.Enabled = false;
            else
            {
                UninstallViGEmBtn.Enabled = false;
                HIDerTab.SelectedIndex = 2;
            }

            if (HIDGuardianAPI.IsHidGuardianInstalled())
                InstallHidGuardianBtn.Enabled = false;
            else
            {
                UninstallHidGuardianBtn.Enabled = false;
                HIDerTab.SelectedIndex = 2;
            }

            if (HIDGuardianAPI.IsHidCerberusAvailable(Application.StartupPath))
            {
                if (HIDGuardianAPI.IsHidCerberusInstalled())
                {
                    InstallHidCerberusBtn.Enabled = false;
                    if (HIDGuardianAPI.IsHidCerberusRunning())
                        StartHidCerberusBtn.Enabled = false;
                    else
                        StopHidCerberusBtn.Enabled = false;
                }
                else
                {
                    UninstallHidCerberusBtn.Enabled = false;
                    StartHidCerberusBtn.Enabled = false;
                    StopHidCerberusBtn.Enabled = false;
                }
            }
            else
            {
                HidCerberusLbl.Visible = false;
                InstallHidCerberusBtn.Visible = false;
                UninstallHidCerberusBtn.Visible = false;
                StartHidCerberusBtn.Visible = false;
                StopHidCerberusBtn.Visible = false;
            }

        }

        private void AppNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // On left click maximize the form.
            {
                this.Show();
                WindowState = FormWindowState.Normal;
            }
            else if (e.Button == MouseButtons.Right) // On right click show the context menu. 
            {
                HiderStausMenu.Visible = true;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) // Minimize to a tray icon and hide the main form.
            {
                Hide();
                AppNotifyIcon.Visible = true;
            }
        }

        private void MenuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm AboutWindow = new AboutForm();
            AboutWindow.StartPosition = FormStartPosition.CenterParent;
            AboutWindow.ShowDialog();
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrayMenuOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void TrayMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
