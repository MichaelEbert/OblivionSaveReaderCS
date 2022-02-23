using OblivionSaveReader;

//Turns a save file into a json text doc.

Task? currentUpload = null;
HttpClient client = new HttpClient();
ProgressWriter progressWriter;
ProgressUploader oblivionSaveUploader;
var prodUrl = "https://michaelebert.github.io/OblivionProgressTracker/data/";
var testUrl = "http://[::1]:8080/data/";
var saveFilePath = "D:\\Users\\Michael\\Documents\\My Games\\Oblivion\\Saves\\Save 295 - Papa Plague - The Great Forest, Level 1, Playing Time 12.17.02.ess";
string myShareCode = "myShareCode";
string myShareKey = "myShareKey";
if(args.Length < 1)
{
    //return;
}

System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());

progressWriter = await ProgressWriter.Create(testUrl, false);
oblivionSaveUploader = new ProgressUploader("progress upload url", myShareKey, myShareCode);

SaveFile saveFile = await ProgressUploader.LoadSaveFile(saveFilePath);
var progressFile = progressWriter.CreateUserProgressFile(saveFile);
var progressAsString = System.Text.Json.JsonSerializer.Serialize(progressFile);
File.WriteAllText("savedata.save", progressAsString, new System.Text.UTF8Encoding(false));




