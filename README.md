# OblivionSaveReaderCS
Oblivion save reader in c#. Reads the last oblivion save in a folder and uploads the progress of it to be visible in the [interactive Oblivion Progress Tracker](https://michaelebert.github.io/OblivionProgressTracker/index.html)
#To Use (1-time,local):
1. Download the (dotnet 6 redistributable)[https://dotnet.microsoft.com/en-us/download/dotnet/6.0]
2. Find the save you want to see the progress of.
3. Drag it on to ConsoleUI.exe. It will create a file called `savedata.save`
4. Go to the [Oblivion Progress Tracker Settings](https://michaelebert.github.io/OblivionProgressTracker/settings.html)
5. Click "Browse..."
6. Find the `savedata.save` file and select it
7. progress should show.

#To Use (continuous upload)
1. Download the (dotnet 6 redistributable)[https://dotnet.microsoft.com/en-us/download/dotnet/6.0]
2. Download release and unzip.
3. Open app.
4. Import your account from the interactive oblivion checklist:
   1. Open up dev tools with f12
   2. go to console and type `settings.myShareCode` for the shareCode and `settings.myShareKey` for the shareKey
   3. Paste these values in to the relevant boxes.
 4. Press "start"
5. Test by copy and pasting a save file. It should show up as "uploaded" in the app.
