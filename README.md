# Infinite PuTTY Tunnel
*Infinite PuTTY Tunnel* allows you to quickly open PuTTY ssh tunnels from the system tray.

## Features

* Quickly start and stop ssh tunnels defined in PuTTY from the system tray.
* Remembers tunnels that were active and will restart them automatically when ipt.exe starts.
* Watchdog: Restart tunnels that have closed unexpectedly.
* TODO: Keep track of open tunnels and prevent multiple tunnels from listening on the same port

## Download and installation

1. Download the latest version from this [page](https://github.com/gdietsche/infinite-tunnel-manager/releases) and place it in your PuTTY directory, or any other directory.
2. Prerequisite: .NET 4.6.1 Framework. This is installed on most modern Microsoft OSes that have windows update enabled.
3. Start Infinite PuTTY Tunnel (ipt.exe).

## Using ipt.exe
1. Configure your tunnel using putty.exe and save it as a session.
3. You MUST use public key authentication.
    * This software does not work with username and passwords because they are insecure.
    * Take a look at Pageant and use it to manage your keys.
2. Run the session using putty.exe and ensure that it connects automatically and DOES NOT prompt you for a username or password. 

## History
This software is a fork of *Putty Tunnel Manager*. The original source which appears to be no longer maintained can be found [here](https://github.com/joeribekker/putty-tunnel-manager).
At this point, this program is nearly a complete rewrite. I've made many changes and have done my best to improve the code and reliability of this software.

