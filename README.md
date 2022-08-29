# ClockMSA_Mqtt
Aim of the project is to create a micro service architecture style binary clock to run on a Raspberry Pi 3/4 (not three quarters!!! 3 or 4).
3 of the projects can run separately and communicate with an mqtt protocol. The mqtt configuration file must be present in the corresponding "bin\Debug\net6.0" folder, named "config.json" if you would like to debug the application. It must have this format:
```
{
 "MqttSettings": {
    "BrokerAddress": "your broker address",
    "UserName": "I think this is quite easy to guess",
    "Password": "this one too"
  }
}
```
## Common project
It contains some common code that is used by all projects, trying to keep it short to reduce linking between projects.

## MqttComm
It used to fire up mqtt communication, it is used by all three main projects.

## TimerMqtt
A quite simple project, it will publish a message on every second that contains the current date time and epoch time in seconds.

## ClockMqtt
It subscribe to the TimerMqtt project's message and as a response publish the calculated led strip values.

## DisplayMqtt
Lastly this will display the values to the given pin on the Raspberry.

## Installer
An "Installer"(I would not call it like that, but I do not have any better idea!) can be downloaded, click on "Actions" => "Publish Installer" => click on the latest green/successful run and download the "Installer" from the artifacts. Unzip the files somewhere, create or copy the "config.json" with valid mqtt config and finally type in a terminal "docker compose up". If you have internet connection to download the latest docker images and docker is available on your machine, it will compose and start all 3 containers.

# TODO
.net timer is not precise enough for controlling a WS2812b led stripe, so I will have to find a workaround. Currently trying to use python script to control the leds.
