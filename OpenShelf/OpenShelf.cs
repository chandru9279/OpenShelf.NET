using System;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenShelf.Models;

namespace OpenShelf
{
    public partial class OpenShelf : Form
    {
        private readonly BackgroundWorker _Worker;
        private Book CurrentBook;
        private Employee CurrentEmployee;
        private JsonSerializer Serializer = new JsonSerializer();
        private QrCam _Cam;


        public OpenShelf()
        {
            InitializeComponent();
            _Worker = new BackgroundWorker();
        }

        private void OpenShelf_Load(object Sender, EventArgs E)
        {
            _Cam = new QrCam();
            _Cam.InitializeWebCam(ref VideoBox);
        }

        private void StartButton_Click(object Sender, EventArgs E)
        {
            _Cam.Start();
            _Worker.DoWork += DoWork;
            _Worker.RunWorkerCompleted += WorkCompleted;
            _Worker.RunWorkerAsync();
        }

        private void StopButton_Click(object Sender, EventArgs E)
        {
            _Cam.Stop();
        }

        private void ContinueButton_Click(object Sender, EventArgs E)
        {
            _Cam.Continue();
        }

        private void VideoFormatButton_Click(object Sender, EventArgs E)
        {
            _Cam.ResolutionSetting();
        }

        private void VideoSourceButton_Click(object Sender, EventArgs E)
        {
            _Cam.AdvanceSetting();
        }

        private void DoWork(object Sender, EventArgs E)
        {
            if (_Cam.WebCamImage == null) return;
            string Decoded = QrCodeUtility.Decode(_Cam.WebCamImage);
            if (!string.IsNullOrEmpty(Decoded))
            {
                if (Decoded.Contains("name"))
                {
                    CurrentEmployee = JsonConvert.DeserializeObject<Employee>(Decoded);
                }
                else if (Decoded.Contains("title"))
                {
                    CurrentBook = JsonConvert.DeserializeObject<Book>(Decoded);
                }
            }
        }

        private void WorkCompleted(object Sender, EventArgs E)
        {
            BookText.Text = CurrentBook == null ? "" : CurrentBook.ToString();
            EmployeeText.Text = CurrentEmployee == null ? "" : CurrentEmployee.ToString();
            if (CurrentEmployee != null && CurrentBook != null)
                Log.Enabled = true;
            _Worker.RunWorkerAsync();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            Log.Enabled = false;
            var Context = new OpenShelfDataContext();
            Context.Borrows.InsertOnSubmit(new Borrow{Id = Guid.NewGuid(), Book = CurrentBook.ToString(), Employee = CurrentEmployee.ToString()});
            Context.SubmitChanges();
            CurrentEmployee = null;
            CurrentBook = null;
        }

        private void ShowLogs_Click(object sender, EventArgs e)
        {
            new LogsView().Show();
        }
    }
}