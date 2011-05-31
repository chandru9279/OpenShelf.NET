using System;
using System.Windows.Forms;

namespace OpenShelf
{
    public partial class OpenShelf : Form
    {
        private Webcam _Cam;

        public OpenShelf()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object Sender, EventArgs E)
        {
            _Cam.Start();
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

        private void OpenShelf_Load(object Sender, EventArgs E)
        {
            _Cam = new Webcam();
            _Cam.InitializeWebCam(ref VideoBox);
        }
    }
}