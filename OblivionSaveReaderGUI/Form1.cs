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
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (settingsChanged)
            {
                settingsChanged = false;
                Properties.Settings.Default.ShareCode = shareCodeTextbox.Text;
                Properties.Settings.Default.ShareKey = shareKeyTextbox.Text;
                Properties.Settings.Default.Save();
            }

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
            saveWatcher = new SaveWatcher((filename) =>
            {
                if(currentUpload == null || (currentUpload.Status == TaskStatus.RanToCompletion || currentUpload.Status == TaskStatus.Faulted || currentUpload.Status == TaskStatus.Canceled))
                {
                    currentUpload = Task.Run(async () =>
                    {
                        var saveFile = await ProgressUploader.LoadSaveFile(filename);
                        var progressFile = progressWriter.CreateUserProgressFile(saveFile);
                        var success = await progressUploader.UploadSave(progressFile);
                        if(success && progressUploader.ShareCode != shareCodeTextbox.Text)
                        {
                            shareCodeTextbox.Text = progressUploader.ShareCode;
                            shareKeyTextbox.Text = progressUploader.ShareKey;
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

        

        private void shareCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }

        private void shareKeyTextbox_TextChanged(object sender, EventArgs e)
        {
            settingsChanged = true;
        }
    }
}