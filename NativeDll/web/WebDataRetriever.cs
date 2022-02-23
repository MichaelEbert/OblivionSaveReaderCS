using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OblivionSaveReader.web
{
    /// <summary>
    /// This class grabs the constants data that we need from the web and parses it.
    /// </summary>
    public class WebDataRetriever
    {
        static readonly HttpClient client = new HttpClient();

        readonly string cacheFolderPath;
        readonly string lastUpdatedFile;

        bool cacheUpdated = false;

        public WebDataRetriever()
        {
            cacheFolderPath = Path.Combine(Path.GetTempPath(), "oblivionSaveReader");
            lastUpdatedFile = Path.Combine(cacheFolderPath, "lastUpdated.txt");
            if (!Directory.Exists(cacheFolderPath))
            {
                Directory.CreateDirectory(cacheFolderPath);
            }
            else
            {
                if (File.Exists(lastUpdatedFile))
                {
                    string lastUpdatedStr = File.ReadAllText(lastUpdatedFile);
                    if (DateTime.TryParse(lastUpdatedStr, out DateTime result))
                    {
                        if (result.AddDays(3) < DateTime.UtcNow)
                        {
                            System.Diagnostics.Trace.WriteLine("Files last downloaded 3 days ago. Refreshing.");
                            //last updated over 3 days ago. Re-download the files.
                            foreach (var filename in Directory.EnumerateFiles(cacheFolderPath))
                            {
                                File.Delete(filename);
                            }
                        }
                    }
                }
            }
        }

        private async Task<string?> getFileData(string filename, string remoteUrl, bool forceRefresh)
        {
            string? fileContents = null;

            string tempFilePath = Path.Combine(cacheFolderPath, filename);
                
            if (File.Exists(tempFilePath) && !forceRefresh)
            {
                fileContents = await File.ReadAllTextAsync(tempFilePath);
            }
            else
            {
                var resp = await client.GetAsync(remoteUrl + filename);
                if (!resp.IsSuccessStatusCode)
                {
                    return null;
                }
                fileContents = await resp.Content.ReadAsStringAsync();
                File.WriteAllText(tempFilePath, fileContents);
                System.Diagnostics.Trace.WriteLine("Downloaded " + filename);
                cacheUpdated = true;
            }
            return fileContents;
        }

        public async Task<Dictionary<string, Hive>> getData(string remoteUrl, bool forceRefresh = false)
        {

            Dictionary<string, Hive> jsondata = new Dictionary<string, Hive>();
            //downloading configuration data...
            foreach(var klass in JsonClass.classes)
            {
                try
                {
                    string filename = klass.name + ".json";
                    string extraFilename = klass.name + "_custom.json";

                    var hiveData = await getFileData(filename, remoteUrl, forceRefresh);
                    var extraData = await getFileData(extraFilename, remoteUrl, forceRefresh);

                    var hive = System.Text.Json.JsonSerializer.Deserialize<Hive>(hiveData);
                    if(hive == null)
                    {
                        continue;
                    }

                    if (extraData != null) {
                        var extra = System.Text.Json.JsonSerializer.Deserialize<Cell[]>(extraData);

                        ObliviondataMjs.MergeData(hive, extra);
                    }

                    jsondata.Add(klass.name, hive);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Trace.Write(ex.StackTrace);
                }
            }
            if (cacheUpdated)
            {
                File.WriteAllText(lastUpdatedFile, DateTime.UtcNow.ToString("o"));
                cacheUpdated = false;
            }
            return jsondata;
        }
    }
}
