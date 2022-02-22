using OblivionSaveReader;
using System.Diagnostics;

namespace OblivionSaveReaderGUI
{
    public partial class OblivionSaveUploader : Form
    {
        private OblivionSaveReader.OblivionSaveUploader? uploader;
        private SaveWatcher? saveWatcher;

        public OblivionSaveUploader()
        {
            InitializeComponent();

            jsonDataUrlTextbox.Text = "https://michaelebert.github.io/OblivionProgressTracker/data/";
            uploadUrlTextbox.Text = "https://ratskip.azurewebsites.net/share";


            MyTraceListener listener = new MyTraceListener(loggingTextBox);
            Trace.Listeners.Add(listener);


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(shareCodeTextbox.Text == "" || shareKeyTextbox.Text == "")
            {
                loggingTextBox.AppendText("Invalid share code/key"+Environment.NewLine);
                return;
            }
            if(uploader == null)
            {
                uploader = new OblivionSaveReader.OblivionSaveUploader(jsonDataUrlTextbox.Text);
            }
            else
            {
                uploader.JsonDataUrl = jsonDataUrlTextbox.Text;
            }
            uploader.PostUrl = uploadUrlTextbox.Text;
            uploader.ShareCode = shareCodeTextbox.Text;
            uploader.ShareKey = shareKeyTextbox.Text;
            uploader.LoadJsonData().ContinueWith((task) =>
            {
                if(saveWatcher != null)
                {
                    saveWatcher.Dispose();
                }
                saveWatcher = new SaveWatcher(uploader.OnFileChanged);
                Trace.WriteLine("Watching directory " + saveWatcher.WatchPath);
                saveWatcher.Start();
            });
        }
    }
}