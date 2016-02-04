# Infinite PuTTY Tunnel
Infinite PuTTY Tunnel allows you to easily open tunnels, that are defined in a PuTTY session, from the system tray.

## Features

* Created specifically for tunneling over SSH sessions
* Open and close sessions from the system tray
* Works alongside PuTTY and Pageant, using Plink
* Keep track of open tunnels and prevent multiple tunnels from listening on the same port
* Reconnects when your PC wakes up from stand-by
* Simple interface
* One file, small size, with a cool icon

## Screenshots

![](http://putty-tunnel-manager.googlecode.com/files/tunneloverview.png)
![](http://putty-tunnel-manager.googlecode.com/files/traymenu.png)

## Download and installation

Like PuTTY, this program is just a single executable file. You will need Microsoft's .NET Framework version 4.6.1 or higher to start it but you'll probably have it already.

1. Download the latest version from this [page](https://github.com/gdietsche/infinite-tunnel-manager/releases) and place it in your PuTTY directory, or any other directory.
1. Download Plink (plink.exe) from [here](http://www.chiark.greenend.org.uk/~sgtatham/putty/download.html) and place it in the same directory.
1. Start Infinite PuTTY Tunnel (ipt.exe).
1. If you put ipt.exe and plink.exe in the same directory, you're ready to go. If not, the settings window will show and you should point to plink.exe yourself.

See the Quick guide to get started.

I also recommend to use Pageant for public key authentication (read: no passwords and even more secure). See the [Using pageant](https://github.com/kthompson/putty-tunnel-manager/wiki/UsingPageant) section for a short explanation.

## History
This software is a fork of "Putty Tunnel Manager". The original source which appears to be no longer maintained can be found [here](https://github.com/joeribekker/putty-tunnel-manager). This fork has removed support for editing Putty session information because that feature was buggy. I've also added features such as dynamically finding new session information so the menu is never out of date. I've also added direct downloading of plink.exe which makes setting up this tool extremely fast. Authenticaion by username and password is no longer supported because it is insecure. Instead, configure your session to use Public/Private keys directly or use Pageant to manage your keys.


