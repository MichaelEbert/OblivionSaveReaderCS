# Oblivion Save Progress Uploader
Oblivion save reader/uploader in c#.

Contains 2 modes:
 1. Turn an Oblivion save into a .save file that can be displayed on the [Interactive Oblivion Progress Tracker](https://michaelebert.github.io/OblivionProgressTracker/index.html).
 2. Continuously upload the latest Oblivion save to the [Interactive Oblivion Progress Tracker](https://michaelebert.github.io/OblivionProgressTracker/index.html) 

# To Use (single save):
1. Download the [dotnet 6 redistributable](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Find the save you want to see the progress of.
3. Drag it on to ConsoleUI.exe. It will create a file called `<charactername>.save` in the folder of the original save file.
4. Go to the [Oblivion Progress Tracker - Settings Page](https://michaelebert.github.io/OblivionProgressTracker/settings.html)
5. Under "Import/Export", Click "Browse..."
6. Find the `<charactername>.save` file and select it. "progress imported" should pop up.
7. Go to main page of progress tracker. Progress should show up.

# To Use (continuous upload)
![Main interface of auto uploader](./doc/appImage.png)
1. Download the [dotnet 6 redistributable](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Download release and unzip.
3. Open app.
4. (Optional) Import your account from the interactive oblivion checklist:
   1. Open up dev tools with f12
   2. go to console and type `settings.myShareCode` for the shareCode and `settings.myShareKey` for the shareKey
   3. Paste these values in to the relevant boxes.
5. Press "start"
6. (optional) To simulate a new save, copy and paste a save file in the oblivion save directory. It should show up as "uploaded" in the app.
