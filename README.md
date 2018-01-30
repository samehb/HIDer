# HIDer
![HIDer](https://i.imgur.com/v9Nv3Yn.png)

## Introduction
HIDer is an open source application that allows you to manage HidGuardian in order to hide chosen controllers from being seen by games/applications (that are not whitelisted). This is useful when some games/applications have issues with specific controllers that are connected.

## Features
1. Provides a GUI for installing/uninstalling ViGEm and HidGuardian drivers.
2. Provides a GUI for managing HidGuardian.
3. Provides HIDGuardianAPI and HIDGuardianWebAPI for developers to manage HidGuardian. HIDGuardianAPI manages the registry directly, while HIDGuardianWebAPI utilizes the REST API provided by HidCerberus.
4. Partially supports x360ce to ViGEm sample application (VDX).
5. Supports refreshing of devices, so that the user does not have to physically unplug the devices. 
6. Supports adding processes to the whitelist permenantly based on file name. Will be extended to path+filname if requested, in the future.
7. Supports storing the selected hidden devices for future runs, so the user does not have to add them on every run.

## Installation

### Prerequisites for ViGEm

1. If you already have ViGEm installed, skip this block to "Prerequisites for HIDer."
2. Download the software and drivers from [here](https://www.microsoft.com/accessories/en-us/products/gaming/xbox-360-controller-for-windows/52a-00004#techspecs-connect) for your operating system. Make sure you select your operating system before clicking the download link.
3. Download [this](https://www.microsoft.com/en-us/download/details.aspx?id=46078) windows update, if you have an x86 operating system (scroll down to see the download button) or [this](https://www.microsoft.com/en-us/download/details.aspx?id=46148) if you have an x64 operating system. You only need one.
4. Install the software and update from step 2-3 and restart your computer.

### Prerequisites for HIDer
1. Start by downloading the file from [here](https://github.com/samehb/HIDer/releases/download/v1.0/HIDer.zip).
2. Extract the file to any folder of choice.
3. Download the HidGuardian and ViGEmBus drivers from [here](https://downloads.vigem.org/stable/latest/windows/x86_64/). If the link changes, find the ViGEm project on Github and go to releases then get the .zip files from there. If you are planning on using "x360ce to ViGEm sample application" aka VDX, get it also from the link.
4. Download [this](https://download.microsoft.com/download/7/D/D/7DD48DE6-8BDA-47C0-854A-539A800FAA90/wdk/Installers/82c1721cd310c73968861674ffc209c9.cab) file if you have an x86 operating system or [this](https://download.microsoft.com/download/7/D/D/7DD48DE6-8BDA-47C0-854A-539A800FAA90/wdk/Installers/787bee96dbd26371076b37b13c405890.cab) file if you have an x64 operating system. Again, download the one for your operating system.
5. Go back to the folder from step 2. Then, put all the files you downloaded from step 1-4 in there (with the exception of VDX). It should look like this:

YourFolder\update\ViGEmBus_signed_Win7-10_x86_x64_latest.zip

YourFolder\update\HidGuardian_signed_Win7-10_x86_x64_latest.zip

YourFolder\update\82c1721cd310c73968861674ffc209c9.cab OR YourFolder\update\787bee96dbd26371076b37b13c405890.cab

6. Make sure all three zipped files are in there, in the update folder.
7. Run the HIDer .exe and it will install all of the three files, then remove them. If everything works as expected, the program will run. In case you are wondering, the 82c1721cd310c73968861674ffc209c9.cab\787bee96dbd26371076b37b13c405890.cab files contain the devcon.exe file which is required for HIDer. If you are a developer, you may compile devcon yourself, though it is not needed.
8. If you are planning on using VDX (x360ce to ViGEm sample application) extract the VDX file into any folder of your liking, you may extract into HIDer's folder if you want, though it is not necessary.

## Usage

1. Connect your devices.
2. Run HIDer as administrator. 
3. If you have not already installed ViGEm and/or HiGuardian, you will be taken directly to the Settings tab. Click the available Install buttons. Then, shut down the application. I would highly recommend restarting your computer, after that, just in case.
3. Now, if you are planning on using VDX (x360ce to ViGEm sample application) this is the time to run it. Make sure you have configured your controller using x360ce.exe and placed the .ini and .dll files inside the folder containing VDX.exe/VDX_x64.exe, before running VDX. The VDX folder should have VDX.exe, VDX_x64.exe, x360ce.ini, and xinput1_3.dll. Also, ALWAYS run VDX before running HIDer or it will not work.
4. Run HIDer now. You will see that you have three tabs.
5. The Devices tab will display the list of available devices that you can hide. Select any of the devices there, then click hide. Repeat for all the devices you want hidden. If you want to undo any of the hidden devices, select the device from the bottom, then click Unhide, or click Unhide (All) to unhide all of the devices.
6. You can confirm that the devices are hidden by checking your controller(s) on Control Panel, or simply by going to "Run" and typing joy.cpl then confirming.
7. If you are using VDX, you can now click Connect to use the virtual device and your system will see that device only.
7. The Processes tab will allow you to add any process to the whitelist used by HidGuardian. Any process on that list will be allowed access to the hidden devices (more or less). This is temporary, though, until you shut down HIDer.
8. If you want to add a process to the whitelist permenanlty, go to the Settings tab, then add the name of the process to the text box to the bottom. You can add it with and without .exe. It is up to you. The application will remove the .exe part for simplification.
9. You can minimize the application and it will be hidden to a tray icon. 
10. After quitting HIDer, the devices will be unhidden for all processes, also the processes will be removed from the whitelist. I am doing this mainly to keep it easy for simple users. When you run the application again, it will re-add the hidden devices from the last run automatically plus the processes from the text box on settings. Just make sure you run those processes before starting HIDer or they will not be added to the whitelist. This is a limitation by the HidGuardian. I can only add processes by their IDs. The IDs change on every run.
11. You will notice that I have added VDX and VDX_x64 on the text box on settings. That is because I want them to be automatically added. Do not remove them from the text box unless you are not using VDX.
12. Always run HIDer before VDX. When in doubt, shutdown HIDer, launch VDX, hide devices (if you have not done that from the last HIDer run), then connect on VDX. Do not connect before launching HIDer.

## Copyright
License: CC BY-NC-SA 4.0 (Attribution-NonCommercial-ShareAlike 4.0 International)

Read file [LICENSE](LICENSE)

## Links

[Blog](http://sres.tumblr.com)

[Project Information]()
