using OblivionSaveReader;
using System.Diagnostics;

namespace OblivionSaveReaderGUI
{
    public partial class OblivionSaveUploader : Form
    {
        private SaveWatcher? saveWatcher;
        private ProgressWriter? progressWriter;
        private ProgressUploader? progressUploader;
        private Task? currentUpload = null;

        public OblivionSaveUploader()
        {
            InitializeComponent();

            jsonDataUrlTextbox.Text = "https://michaelebert.github.io/OblivionProgressTracker/data/";
            uploadUrlTextbox.Text = "https://ratskip.azurewebsites.net/share";


            MyTraceListener listener = new MyTraceListener(loggingTextBox);
            Trace.Listeners.Add(listener);


        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if(shareCodeTextbox.Text == "" || shareKeyTextbox.Text == "")
            {
                loggingTextBox.AppendText("Invalid share code/key"+Environment.NewLine);
                return;
            }

            progressWriter = await ProgressWriter.Create(jsonDataUrlTextbox.Text, forceRefreshCheckbox.Checked);
            progressUploader = new ProgressUploader(uploadUrlTextbox.Text, shareCodeTextbox.Text, shareKeyTextbox.Text);
            
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
                        await progressUploader.UploadSave(progressFile);
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
    }
}