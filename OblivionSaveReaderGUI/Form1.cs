using OblivionSaveReader;
using System.Configuration;
using System.Diagnostics;
using System.Resources;

namespace OblivionSaveReaderGUI
{
    public partial class OblivionSaveUploader : Form
    {
        private SaveWatcher? saveWatcher;
        private ProgressWriter? progressWriter;
        private ProgressUploader? progressUploader;
        private Task? currentUpload = null;
        /// <summary>
        /// Mark if settings have changed and we should save.
        /// </summary>
        private bool settingsChanged = false;

        public OblivionSaveUploader()
        {
            InitializeComponent();


            jsonDataUrlTextbox.Text = "https://michaelebert.github.io/OblivionProgressTracker/data/";
            uploadUrlTextbox.Text = "https://ratskip.azurewebsites.net/share";


            MyTraceListener listener = new MyTraceListener(loggingTextBox);
            Trace.Listeners.Add(listener);

            //upgrade stuff
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            string? currentAppVersion = a.GetName().Version?.ToString();
            if(currentAppVersion != null)
            {
                if (Properties.Settings.Default.ApplicationVersion != currentAppVersion)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.ApplicationVersion = currentAppVersion;
                }
            }

            shareCodeTextbox.Text = Properties.Settings.Default.ShareCode;
            shareKeyTextbox.Text = Properties.Settings.Default.ShareKey;
            if(!string.IsNullOrEmpty(Properties.Settings.Default.SaveDirectory))
            {
                saveFileDirectoryTextbox.PlaceholderText = Properties.Settings.Default.SaveDirectory;
            }
            else
            {
                saveFileDirectoryTextbox.PlaceholderText = SaveWatcher.GetDefaultSaveLocation();
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            saveSettings();

            progressWriter = await ProgressWriter.Create(jsonDataUrlTextbox.Text, forceRefreshCheckbox.Checked);
            if(shareKeyTextbox.Text.Length == 0)
            {
                progressUploader = new ProgressUploader(uploadUrlTextbox.Text);
            }
            else
            {
                progressUploader = new ProgressUploader(uploadUrlTextbox.Text, shareCodeTextbox.Text, shareKeyTextbox.Text);
            }
            
            
            if(saveWatcher != null)
            {
                saveWatcher.Dispose();
            }

            string? maybeSaveFileName = saveFileDirectoryTextbox.Text;
            saveWatcher = new SaveWatcher(maybeSaveFileName , (filename) =>
            {
                if(currentUpload == null || (currentUpload.Status == TaskStatus.RanToCompletion || currentUpload.Status == TaskStatus.Faulted || currentUpload.Status == TaskStatus.Canceled))
                {
                    currentUpload = Task.Run(async () =>
                    {
                        var saveFile = await ProgressUploader.LoadSaveFile(filename);
                        var progressFile = progressWriter.CreateUserProgressFile(saveFile);
                        var success = await progressUploader.UploadSave(progressFile);
                        if (success && progressUploader.ShareCode != shareCodeTextbox.Text)
                        {
                            this.Invoke(() =>
                            {
                                shareCodeTextbox.Text = progressUploader.ShareCode;
                                shareKeyTextbox.Text = progressUploader.ShareKey;
                                settingsChanged = true;
                                saveSettings();
                            });
                        }
                    }).ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            Trace.WriteLine("Exception encounterd during processing:");
                            Trace.Write(task.Exception?.ToString());
                            currentUpload = null;
                        }
                    });
                }
                else
                {
                    Trace.WriteLine("Skipping upload since upload already in progress.");
                }
            });
            Trace.WriteLine("Watching directory " + saveWatcher.WatchPath);
            saveWatcher.Start();
        }

        /// <summary>
        /// If the settingsChanged flag has been set, save settings.
        /// </summary>
        private void saveSettings()
        {
            if (settingsChanged)
            {
                settingsChanged = false;
                Properties.Settings.Default.ShareCode = shareCodeTextbox.Text;
                Properties.Settings.Default.ShareKey = shareKeyTextbox.Text;
                Properties.Settings.Default.SaveDirectory = saveFileDirectoryTextbox.Text;
                Properties.Settings.Default.Save();
            }
        }

        

        private void shareCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void shareKeyTextbox_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void saveFileDirectoryTextbox_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }
    }
}