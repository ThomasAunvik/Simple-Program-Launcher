# Simple-Program-Launcher
This is a simple project made in C# Forms that you can use as a launcher for any windows .exe application

It contains the features you need to create a launcher that needs to automaticly download programs when there is one.

## Setup for your own program:
1. Download Source Files.
2. Setup a file where the file path is permanent (sorry).
This file is going to be a json file which contains this:
```json
{
	version: "version",
	url: "direct download url"
}
```
3. Now set the file url into the `JsonWebLink`.
4. Make sure the `ApplicationName` is the same as your .exe file. (if you want you could add that into the json file and get the application name).
5. Start the program and hit the Download button, (it will soon turn into Play after downloading).

### Note:
THIS PROJECT CURRENTLY DOWNLOADS MY APPLICATION (THIS APPLICATION), WHICH WILL THEN RUN AGAIN IF YOU PRESS PLAY, TO AUTOMATICLY REMOVE THE FILES PRESS `Force Update` ON TOP OF THE FOLDER. AND MAKE SURE ALL OF THE PROGRAMS ARE CLOSED.
