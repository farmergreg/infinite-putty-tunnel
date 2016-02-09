# Infinite PuTTY Tunnel ([download ipt.exe](https://github.com/dietsche/infinite-putty-tunnel/releases/latest/))
*Infinite PuTTY Tunnel* allows you to quickly open persistent ssh tunnels from your system tray using [PuTTY](http://www.chiark.greenend.org.uk/~sgtatham/putty/).

## Features

- **Quick:** Start and stop ssh tunnels [defined in PuTTY](http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter4.html#config-ssh-portfwd) from the system tray.
- **Persistent Tunnels:** Remember active tunnels and restart them automatically when ipt.exe is launched.
- **Watchdog:** Restart tunnels that close unexpectedly.
- **Secure:** No support for password based authentication because it is insecure.
- **Department Of Redundancy:** *TODO:* Keep track of open tunnels and prevent multiple tunnels from listening on the same port

## Screen Shots

![](screen-shots/SystemTray-Menu.png)
![](screen-shots/SystemTray-CurrentTunnels.png)

## Best Practices
1. Configure your tunnel [using putty.exe](http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter4.html#config-ssh-portfwd) and save it as a session.
2. [Configure Pageant](http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter9.html#pageant-cmdline-command) to start ipt.exe after your keys are loaded.
3. Using PuTTY, Ensure that the session works and does not trigger any interactive prompts.
4. Begin using *Infinite PuTTY Tunnel* to automatically start and maintain your tunnel.

## Installation

1. Install the .NET 4.6.1 Framework. Most computers will already have this installed via Windows Update.
2. Install the latest version of [PuTTY](http://the.earth.li/~sgtatham/putty/latest/x86/putty-0.66-installer.exe).
3. Install the [latest version](https://github.com/dietsche/infinite-putty-tunnel/releases/latest/) of *Infinite PuTTY Tunnel*.
4. Configure a tunnel [using PuTTY](http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter4.html#config-ssh-portfwd) and save it as a session, and test to make sure the tunnel works properly.
5. Start Infinite PuTTY Tunnel (ipt.exe).
6. Use the system tray icon to start your pre-configured ssh tunnel!

## History
This software is a fork of *PuTTY Tunnel Manager*. The [original](https://github.com/joeribekker/putty-tunnel-manager) appears to be no longer maintained.
This program is nearly a complete rewrite of the original *Putty Tunnel Manager*. I've made many changes and have done my best to improve the reliability and code quality of this software.
