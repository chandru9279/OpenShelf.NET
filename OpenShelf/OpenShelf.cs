using System;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace OpenShelf
{
    public partial class OpenShelf : Form
    {
        private readonly BackgroundWorker _Worker;
        private JsonSerializer Serializer = new JsonSerializer();
        private BorrowSession _BorrowSession;
        private QrCam _Cam;


        public OpenShelf()
        {
            InitializeComponent();
            _BorrowSession = new BorrowSession();
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
                _BorrowSession.Decode(Decoded);
            }
        }

        private void WorkCompleted(object Sender, EventArgs E)
        {
            if (_BorrowSession.isAtomic())
            {
                Log.Enabled = true;
                _BorrowSession.Save();
                _BorrowSession = new BorrowSession();
            }
            _Worker.RunWorkerAsync();
        }

        private void ShowLogs_Click(object sender, EventArgs e)
        {
            new LogsView().Show();
        }

        private void Log_Click(object sender, EventArgs e)
        {

        }
    }

    public class BorrowSession
    {
        public Book _ChosenBook { get; private set; }
        public ThoughtWorker _ChosenThoughtWorker { get; private set; }
        private OpenShelfContainer OpenShelfContainer;

        public BorrowSession()
        {
            OpenShelfContainer = new OpenShelfContainer();
        }

        public void Decode(string Decoded)
        {
            if (Decoded.Contains("OpenShelf"))
            {
                if (Decoded.Contains("empId"))
                {
                    _ChosenThoughtWorker = JsonConvert.DeserializeObject<ThoughtWorker>(Decoded);
                }
                else if (Decoded.Contains("bookId"))
                {
                    _ChosenBook = JsonConvert.DeserializeObject<Book>(Decoded);
                }
            }
        }

        public bool isAtomic()
        {
            return (null != _ChosenBook) && (null != _ChosenThoughtWorker);
        }

        public void Save()
        {
            var SelectedBook = OpenShelfContainer.Books.Find(_ChosenBook.id);
            var SelectedThoughtWorker = OpenShelfContainer.ThoughtWorkers.Find(_ChosenBook.id);
            OpenShelfContainer.BorrowDetails.Add(new BorrowDetails
                                                     {book = SelectedBook, thoughtworker = SelectedThoughtWorker});
            OpenShelfContainer.SaveChanges();

        }
    }
}
