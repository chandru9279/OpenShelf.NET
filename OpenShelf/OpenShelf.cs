using System;
using System.ComponentModel;
using System.Diagnostics;
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
                _BorrowSession.SaveSession();
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
        public BookCopy _ChosenBookCopy { get; private set; }
        public ThoughtWorker _ChosenThoughtWorker { get; private set; }
        public static int DummyThoughtWorker = 101010;
        private OpenShelfContainer OpenShelfContainer;

        public BorrowSession()
        {
            OpenShelfContainer = new OpenShelfContainer();
        }

        public void Decode(string Decoded)
        {
            if (Decoded.Contains("empId"))
            {
                _ChosenThoughtWorker = JsonConvert.DeserializeObject<ThoughtWorker>(Decoded);
            }
            else if (Decoded.Contains("CopyId"))
            {
                _ChosenBookCopy = JsonConvert.DeserializeObject<BookCopy>(Decoded);
            }
        }

        public bool isAtomic()
        {
            return (null != _ChosenBookCopy) && (null != _ChosenThoughtWorker);
        }

        public void SaveSession()
        {
            BookCopy bookCopy = OpenShelfContainer.BookCopies.Find(_ChosenBookCopy.CopyId);
            if (bookCopy.AvailabilityStatus.Equals(AvailabilityStatus.AVAILABLE))
            {
                bookCopy.AvailabilityStatus = AvailabilityStatus.RESERVED;
                bookCopy.ThoughtWorkerId = _ChosenThoughtWorker.empId;
            } else
            {
                bookCopy.AvailabilityStatus = AvailabilityStatus.AVAILABLE;
                bookCopy.ThoughtWorker = OpenShelfContainer.ThoughtWorkers.Find(DummyThoughtWorker);
            }
            OpenShelfContainer.SaveChanges();
            Trace.WriteLine("Borrow Operation Saved");
        }
    }

    public class AvailabilityStatus
    {
        public static string AVAILABLE = "A";
        public static string RESERVED = "R";
    }
}
