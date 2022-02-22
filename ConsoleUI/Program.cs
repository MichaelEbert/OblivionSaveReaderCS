// See https://aka.ms/new-console-template for more information
using OblivionSaveReader;
using OblivionSaveReader.web;

Task? currentUpload = null;
HttpClient client = new HttpClient();

var prodUrl = "https://michaelebert.github.io/OblivionProgressTracker/data/";
var testUrl = "http://[::1]:8080/data/";
var saveFilePath = "D:\\Users\\Michael\\Documents\\My Games\\Oblivion\\Saves\\Save 295 - Papa Plague - The Great Forest, Level 1, Playing Time 12.17.02.ess";
string myShareCode = "myShareCode";
string myShareKey = "myShareKey";

System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());

var uploader = new OblivionSaveUploader(testUrl);
var loadTask = uploader.LoadJsonData();

Console.WriteLine("Listening for saves...");
using (SaveWatcher sw = new SaveWatcher(uploader.OnFileChanged))
{
    sw.Start();
    while (true)
    {
        Thread.Sleep(1000);
    }
}



