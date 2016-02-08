# Infinite PuTTY Tunnel
*Infinite PuTTY Tunnel* allows you to quickly open [PuTTY](http://www.chiark.greenend.org.uk/~sgtatham/putty/) ssh tunnels from the system tray.

## Features

* Quickly start and stop ssh tunnels defined in PuTTY from the system tray.
* Remembers tunnels that were active and will restart them automatically when ipt.exe starts.
* Watchdog: Restart tunnels that have closed unexpectedly.
* No support for password based authentication because it is insecure.
* TODO: Keep track of open tunnels and prevent multiple tunnels from listening on the same port

## Best Practices
1. Configure your tunnel using putty.exe and save it as a session.
2. [Configure Pageant](http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter9.html#pageant-cmdline-command) to start ipt.exe after your keys are loaded.
3. Using PuTTY, Ensure that the session works and does not trigger any user prompts.
4. Begin using *Infinite PuTTY Tunnel* to automatically start and maintain your tunnel.

## Installation

1. Install the .NET 4.6.1 Framework. Most computers will already have this installed via Windows Update.
2. Install the latest version of [PuTTY](http://the.earth.li/~sgtatham/putty/latest/x86/putty-0.66-installer.exe).
3. Install the latest [version](https://github.com/dietsche/infinite-putty-tunnel/releases) of *Infinite PuTTY Tunnel*.
4. Configure a tunnel using PuTTY and save it as a session, and test to make sure the tunnel works properly.
5. Start Infinite PuTTY Tunnel (ipt.exe).
6. Use the system tray icon to start your pre-configured ssh tunnel!

## Screen Shots

![](screen-shots/SystemTray-Menu.png)
![](screen-shots/SystemTray-CurrentTunnels.png)

## History
This software is a fork of *PuTTY Tunnel Manager*. The [original](https://github.com/joeribekker/putty-tunnel-manager) appears to be no longer maintained.
This program is nearly a complete rewrite of the original *Putty Tunnel Manager*. I've made many changes and have done my best to improve the reliability and code quality of this software.
