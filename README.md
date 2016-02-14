# Infinite PuTTY Tunnel ([download ipt.exe][current-release])
[![Build Status](https://travis-ci.org/dietsche/infinite-putty-tunnel.svg)](https://travis-ci.org/dietsche/infinite-putty-tunnel)
*Infinite PuTTY Tunnel* allows you to quickly open and maintain persistent ssh tunnels from your system tray using [PuTTY][putty].

## Features

- **Simple:** Start and stop ssh tunnels [defined in PuTTY][putty-config-ssh-portfwd] from your system tray.
- **Persistent Tunnels:** Automatically restart previously active tunnels when ipt.exe starts.
- **Watchdog:** Restart tunnels that close unexpectedly.
- **Secure:** No support for password based authentication because it is insecure.
- **Department of Redundancy Department:** *TODO:* Keep track of open tunnels and prevent multiple tunnels from listening on the same port

## Screen Shots

![](screen-shots/SystemTray-Menu.png)
![](screen-shots/SystemTray-CurrentTunnels.png)

## Installation

1. Download and install the [.NET 4.6.1 Framework] [dot-net]. Most computers will already have this installed via Windows Update
2. [Download][putty-installer] and install the latest version of PuTTY
3. Download and install the [latest version] [current-release] of *Infinite PuTTY Tunnel* (ipt.exe)

## Configuration

1. [Configure your tunnel][putty-config-ssh-portfwd] using putty.exe and [save it as a session][putty-config-session]
2. [Configure Pageant][putty-pageant-cmdline-command] to start ipt.exe after your keys are loaded
3. Using PuTTY, Ensure that the session works and does not trigger any interactive prompts
4. Begin using *Infinite PuTTY Tunnel* to automatically start and maintain your tunnel

## History
This software is a fork of *PuTTY Tunnel Manager*. The [original][downstream] appears to be no longer maintained.
This program is nearly a complete rewrite of the original *Putty Tunnel Manager*. I've made many changes and have done my best to improve the reliability and code quality of this software.

[current-release]: https://github.com/dietsche/infinite-putty-tunnel/releases/latest/
[downstream]: https://github.com/joeribekker/putty-tunnel-manager
[putty]: http://www.chiark.greenend.org.uk/~sgtatham/putty/
[putty-installer]: http://the.earth.li/~sgtatham/putty/latest/x86/putty-installer.exe
[putty-config-ssh-portfwd]: http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter4.html#config-ssh-portfwd
[putty-config-session]: http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter4.html#config-session
[putty-pageant-cmdline-command]: http://the.earth.li/~sgtatham/putty/latest/htmldoc/Chapter9.html#pageant-cmdline-command
[dot-net]: https://www.microsoft.com/en-us/download/details.aspx?id=49981
