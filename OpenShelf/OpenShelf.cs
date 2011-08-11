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
        private BorrowSession _BorrowSession;
        private QrCam _Cam;
        public static string DefaultBookStatus = "Chosen Book: ";
        public static string DefaultUserStatus = "Chosen User: ";
        public static string DefaultStatusText = "Status: ";

        public OpenShelf()
        {
            InitializeComponent();
            _BorrowSession = new BorrowSession();
            _Worker = new BackgroundWorker();

            try
            {
                var openShelfContainer = new OpenShelfContainer();
                int DummyUser = 101010;
                openShelfContainer.ThoughtWorkers.Find(DummyUser);
                Logger.append("DB Connection succeeded", Logger.ALL);
            } catch(Exception E)
            {
                Logger.append("Exception while Initializing: " + E.StackTrace, Logger.ALL);
            }
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
            StartButton.Enabled = false;
            StopButton.Enabled = true;
        }

        private void StopButton_Click(object Sender, EventArgs E)
        {
            _Cam.Stop();
            StartButton.Enabled = true;
            StopButton.Enabled = false;
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

        private void DoWork(object Sender, DoWorkEventArgs E)
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
                SaveStatus();
                UpdateFormValues();
                _BorrowSession = new BorrowSession();
                ResetFormValuesAfterSomeInterval();
            }
            _Worker.RunWorkerAsync();
        }

        private void UpdateFormValues()
        {
            BookText.Text = DefaultBookStatus + _BorrowSession._ChosenBookCopy.BookObj.Title;
            ThoughtWorkerText.Text = DefaultUserStatus + _BorrowSession._ChosenThoughtWorker.Name;
            StatusText.Text = DefaultStatusText +
                              AvailabilityStatus.GetStatusLabel(_BorrowSession._ChosenBookCopy.AvailabilityStatus);
        }

        private void SaveStatus()
        {
            StatusText.Text = DefaultStatusText + _BorrowSession._ChosenBookCopy.AvailabilityStatus;
        }

        private void ResetFormValuesAfterSomeInterval()
        {
            ResetTimer.Enabled = true;
        }

        private void ShowLogs_Click(object sender, EventArgs e)
        {
            new LogsView().Show();
        }

        private void Log_Click(object sender, EventArgs e)
        {
        }

        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            BookText.Text = DefaultBookStatus;
            ThoughtWorkerText.Text = DefaultUserStatus;
            StatusText.Text = DefaultStatusText;
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
                _ChosenThoughtWorker = OpenShelfContainer.ThoughtWorkers.Find(_ChosenThoughtWorker.empId);
                PlayBeep();
            }
            else if (Decoded.Contains("CopyId"))
            {
                _ChosenBookCopy = OpenShelfContainer.BookCopies.Find(JsonConvert.DeserializeObject<BookDTO>(Decoded).CopyId);
                PlayBeep();
            }
        }

        public void PlayBeep()
        {
            new System.Media.SoundPlayer {SoundLocation = @"c:\beep.wav"}.Play();
        }

        public bool isAtomic()
        {
            return (null != _ChosenBookCopy) && (null != _ChosenThoughtWorker);
        }

        public void SaveSession()
        {
            if (_ChosenBookCopy.AvailabilityStatus.Equals(AvailabilityStatus.AVAILABLE))
            {
                _ChosenBookCopy.AvailabilityStatus = AvailabilityStatus.RESERVED;
                _ChosenBookCopy.ThoughtWorker = _ChosenThoughtWorker;
            }
            else
            {
                if (_ChosenThoughtWorker.empId.Equals(_ChosenBookCopy.ThoughtWorkerId))
                {
                    _ChosenBookCopy.AvailabilityStatus = AvailabilityStatus.AVAILABLE;
                    _ChosenBookCopy.ThoughtWorker = OpenShelfContainer.ThoughtWorkers.Find(DummyThoughtWorker);
                }
            }
            OpenShelfContainer.SaveChanges();
            Trace.WriteLine("Borrow Operation Saved");
        }
    }

    public class BookDTO
    {
        public decimal CopyId { get; set; }
        public decimal BookId { get; set; }
    }

    public class AvailabilityStatus
    {
        public static string AVAILABLE = "A";
        public static string RESERVED = "R";

        public static string GetStatusLabel(string Status)
        {
            if ("R".Equals(Status))
                return "Reserved";
            return "Available";
        }
    }
}