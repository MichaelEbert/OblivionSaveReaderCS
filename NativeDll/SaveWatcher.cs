using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader
{
    public class SaveWatcher : IDisposable
    {
        public string WatchPath { get; private set; }
        FileSystemWatcher watcher;
        private bool disposedValue;

        private Action<string> onFileChanged;

        public SaveWatcher(string watchPath, Action<string> onFileChanged)
        {
            this.onFileChanged = onFileChanged;
            this.WatchPath = watchPath;
            watcher = new FileSystemWatcher(watchPath);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            watcher.Changed += OnUpdate;
        }

        //this is windows only. 
        public SaveWatcher(Action<string> onFileChanged)
        {
            this.onFileChanged = onFileChanged;
            //get documents path, then append save folder location.
            const string myGamesPath = "My Games\\Oblivion\\Saves";
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            WatchPath = Path.Combine(path, myGamesPath);
            if (!Directory.Exists(WatchPath))
            {
                throw new DirectoryNotFoundException(WatchPath);
            }
            watcher = new FileSystemWatcher(WatchPath);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            //watcher.Created += OnUpdate;
            watcher.Changed += OnUpdate;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void OnUpdate(object sender, FileSystemEventArgs args)
        {
            //TODO: run the stuff.
            if(args.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            if (!args.FullPath.EndsWith(".ess"))
            {
                return;
            }
            onFileChanged(args.FullPath);
            return;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
