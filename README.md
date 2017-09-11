## Open Hardware Monitor - Arduino

Read CPU and GPU temperature readings, then display them on Arduino LCD.

-----

### Requirements

1. Visual Studio 2017 with latest update
2. Windows 10 with .Net Framework 4.6.2
3. Arduino with LCD
4. Official Arduino IDE

### Usage

1. Download the latest source code (i.e. master zip) of [Open Hardware Monitor](https://github.com/openhardwaremonitor/openhardwaremonitor) and open it with VS2017. Then,
change the target platform of `OpenHardwareMonitorLib` to `.Net Framework 4.6.2`. Build this project (there is no need to build its GUI).
2. Connect Arduino and upload `arduino\ohm-arduino.ino`
3. Download this project, and modify `mainTimer_Tick` to fit your need.
4. Compile and run.

### Credits

Temperature data obtained from [Open Hardware Monitor](https://github.com/openhardwaremonitor/openhardwaremonitor)'s `OpenHardwareMonitorLib`

Icons made by [Pixel Buddha](https://www.flaticon.com/authors/pixel-buddha) from [www.flaticon.com](https://www.flaticon.com/) 
is licensed by [CC 3.0 BY](http://creativecommons.org/licenses/by/3.0/)