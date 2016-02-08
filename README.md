# Infinite PuTTY Tunnel
*Infinite PuTTY Tunnel* allows you to quickly open [PuTTY](http://www.chiark.greenend.org.uk/~sgtatham/putty/) ssh tunnels from the system tray.

## Features

* Quickly start and stop ssh tunnels defined in PuTTY from the system tray.
* Remembers tunnels that were active and will restart them automatically when ipt.exe starts.
* Watchdog: Restart tunnels that have closed unexpectedly.
* TODO: Keep track of open tunnels and prevent multiple tunnels from listening on the same port

## Download and installation

1. Install the .NET 4.6.1 Framework. Most computers will already have this installed.
2. Download the latest version of [PuTTY](http://the.earth.li/~sgtatham/putty/latest/x86/putty-0.66-installer.exe).
3. Download the latest [version](https://github.com/dietsche/infinite-putty-tunnel/releases) of *Infinite PuTTY Tunnel*.
4. Configure a tunnel using Putty and save it as a session, and test to make sure the tunnel works properly.
5. Start Infinite PuTTY Tunnel (ipt.exe).
6. Use the system tray icon to start your pre-configured ssh tunnel!

## Using ipt.exe
1. Configure your tunnel using putty.exe and save it as a session.
2. Run the session using putty.exe and ensure that it connects automatically and DOES NOT prompt you for a username or password. 
3. You MUST use public key authentication.
    * This software does not work with username and passwords because they are insecure.
    * Take a look at Pageant and use it to manage your keys.

## Screen Shots

![](screen-shots/SystemTray-Menu.png)
![](screen-shots/SystemTray-CurrentTunnels.png)

## History
This software is a fork of *Putty Tunnel Manager*. The [original](https://github.com/joeribekker/putty-tunnel-manager) appears to be no longer maintained.
This program is nearly a complete rewrite of the original *Putty Tunnel Manager*. I've made many changes and have done my best to improve the reliability and code quality of this software.

