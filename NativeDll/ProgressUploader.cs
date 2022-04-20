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
	public class ProgressUploader
    {
        Task? currentUpload = null;
        static readonly HttpClient httpClient = new HttpClient();

        public string? ShareCode { get; set; }
        public string ShareKey { get; set; }
        public string PostUrl { get; set; }

        public ProgressUploader(string postUrl)
        {
            this.PostUrl = postUrl;
            this.ShareKey = GenerateShareKey();
        }

        public ProgressUploader(string postUrl, string shareCode, string shareKey)
        {
            ShareCode = shareCode;
            ShareKey = shareKey;
            PostUrl = postUrl;
        }

        /// <summary>
        /// Small wrapper around File.ReadAllBytes to load a save file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static async Task<SaveFile> LoadSaveFile(string filepath)
        {
            Byte[] bytes;
            try
            {
                bytes = await File.ReadAllBytesAsync(filepath);
            }
            catch (IOException)
            {
                //try waiting in case we just need to wait for oblivion to close the file
                Thread.Sleep(500);
                bytes = await File.ReadAllBytesAsync(filepath);
            }
            return new SaveFile(bytes);
        }

        /// <summary>
        /// Upload a save file. Only uploads 1 at a time.
        /// </summary>
        /// <param name="progressFile"></param>
        /// <returns></returns>
        public async Task<bool> UploadSave(DObject progressFile)
        {
            var saveData = System.Text.Json.JsonSerializer.Serialize(progressFile);
            Dictionary<string, string> payload;
            System.Diagnostics.Trace.WriteLine("Uploading file");
            if (ShareCode != null)
            {
                payload = new Dictionary<string, string>
                    {
                        { "saveData", saveData},
                        { "url", ShareCode },
                        { "key", ShareKey }
                    };
            }
            else
            {
                payload = new Dictionary<string, string>
                    {
                        { "saveData", saveData},
                        { "key", ShareKey }
                    };
            }

            HttpContent content = JsonContent.Create(payload);
            var resp = await httpClient.PostAsync(PostUrl, content);
            var respContent = await resp.Content.ReadAsStringAsync();
            if (resp.IsSuccessStatusCode)
            {
                System.Diagnostics.Trace.WriteLine("File uploaded.");
                if (respContent != null && respContent.Length > 0)
                {
                    System.Diagnostics.Trace.WriteLine("share code: " + respContent);
                    //change sharecode
                    ShareCode = respContent;
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("Upload failed with " + respContent);
            }
            return resp.IsSuccessStatusCode;
        }

        public void OnFileChanged(string filepath, ProgressWriter writer)
        {
            System.Diagnostics.Trace.WriteLine("Found changed file: " + filepath);
            if (currentUpload == null || currentUpload.Status == TaskStatus.RanToCompletion)
            {
                currentUpload = Task.Run(async () =>
                {
                    SaveFile saveFile = await LoadSaveFile(filepath);
                    var saveObject = writer.CreateUserProgressFile(saveFile);
                    var success = await UploadSave(saveObject);
                }).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        System.Diagnostics.Trace.WriteLine("Exception encounterd during processing:");
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

        public static string GenerateShareKey()
        {
            Random rand = new Random();
            byte[] bytes = new byte[64];
            rand.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
