using OblivionSaveReader.web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader
{
	//idk what to call this. progress loading/writing functions
	public class OblivionSaveUploader
    {
        Task? currentUpload = null;
        static readonly HttpClient httpClient = new HttpClient();

        public string JsonDataUrl { get; set; }
        public string ShareCode { get; set; }
        public string ShareKey { get; set; }
        public string PostUrl { get; set; }

        private Dictionary<string, Hive>? hiveData;
        private UserdataMjs userdataMjs;
        private ProgressWriter progressWriter;

        public OblivionSaveUploader(string JsonDataUrl)
        {
            this.JsonDataUrl = JsonDataUrl;
        }

        public async Task LoadJsonData()
        {
            System.Diagnostics.Trace.WriteLine("Loading JSON data");
            WebDataRetriever retriever = new WebDataRetriever();
            var hivesTask = Task.Run(() => retriever.getData(JsonDataUrl, false));
            hiveData = await hivesTask;
            userdataMjs = new UserdataMjs(hiveData);
            progressWriter = new ProgressWriter(hiveData);
        }

        public void aaa()
        {

            var prodUrl = "https://michaelebert.github.io/OblivionProgressTracker/data/";
            var testUrl = "http://[::1]:8080/data/";
            var saveFilePath = "D:\\Users\\Michael\\Documents\\My Games\\Oblivion\\Saves\\Save 295 - Papa Plague - The Great Forest, Level 1, Playing Time 12.17.02.ess";
            string myShareCode = "myShareCode";
            string myShareKey = "myShareKey";

            Console.WriteLine("Loading JSON data");
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());

            LoadJsonData();
            Console.WriteLine("Listening for saves...");
            using (SaveWatcher sw = new OblivionSaveReader.SaveWatcher(OnFileChanged))
            {
                sw.Start();
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static SaveFile LoadSaveFile(string filepath)
        {
            //load file, then send to SaveFile.
            //convert to byte array.

            var bytes = File.ReadAllBytes(filepath);
            var saveFile = new SaveFile(bytes);
            return saveFile;
        }

        private async Task<bool> UploadSave(string saveData)
        {
            System.Diagnostics.Trace.WriteLine("Uploading file");
            var payload = new Dictionary<string, string>
                    {
                        { "saveData", saveData},
                        { "url", ShareCode },
                        { "key", ShareKey }
                    };

            HttpContent content = JsonContent.Create(payload);
            var resp = await httpClient.PostAsync(PostUrl, content);
            if (resp.IsSuccessStatusCode)
            {
                System.Diagnostics.Trace.WriteLine("File uploaded.");
            }
            else
            {
                var respError = await resp.Content.ReadAsStringAsync();
                System.Diagnostics.Trace.WriteLine("Upload failed with "+respError);
            }
            return resp.IsSuccessStatusCode;
            
        }

        public void OnFileChanged(string filepath)
        {
            System.Diagnostics.Trace.WriteLine("Found changed file: " + filepath);
            if (currentUpload == null || currentUpload.Status == TaskStatus.RanToCompletion)
            {
                currentUpload = Task.Run(async () =>
                {
                    SaveFile saveFile;
                    try
                    {
                        saveFile = LoadSaveFile(filepath);
                    }
                    catch(IOException)
                    {
                        //sleep 500ms to give a chance to close the file.
                        Thread.Sleep(500);
                        saveFile = LoadSaveFile(filepath);
                    }
                    var saveObject = progressWriter.CreateUserProgressFile(saveFile);
                    //var saveObject = userdata.resetProgress();

                    //save data and write to file
                    var newSaveData = System.Text.Json.JsonSerializer.Serialize(saveObject);
                    //async upload.
                    var success = await UploadSave(newSaveData);
                }).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        System.Diagnostics.Trace.WriteLine("Exception encounterd during upload:");
                        System.Diagnostics.Trace.Write(task.Exception?.ToString());
                        currentUpload = null;
                    }
                });
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("Skipping upload, existing one already in progress.");
            }
            return;
        }
    }
}
