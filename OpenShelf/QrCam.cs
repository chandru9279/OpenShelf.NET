using System.Drawing;
using System.Windows.Forms;
using WebCam_Capture;

namespace OpenShelf
{
    internal class QrCam
    {
        private PictureBox _FrameImage;
        private WebCamCapture _Webcam;

        public Image WebCamImage { get; set; }

        public int FrameRate { get; set; }

        public void InitializeWebCam(ref PictureBox ImageControl)
        {
            FrameRate = 1;
            _Webcam = new WebCamCapture {FrameNumber = 0ul, TimeToCapture_milliseconds = FrameRate};
            _Webcam.ImageCaptured += WebcamImageCaptured;
            _FrameImage = ImageControl;
        }

        private void WebcamImageCaptured(object Source, WebcamEventArgs E)
        {
            WebCamImage = E.WebCamImage;
            _FrameImage.Image = (Image) WebCamImage.Clone();
       }

        public void Start()
        {
            _Webcam.TimeToCapture_milliseconds = FrameRate;
            _Webcam.Start(0);
        }

        public void Stop()
        {
            _Webcam.Stop();
        }

        public void Continue()
        {
            _Webcam.TimeToCapture_milliseconds = FrameRate;
            _Webcam.Start(_Webcam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            _Webcam.Config();
        }

        public void AdvanceSetting()
        {
            _Webcam.Config2();
        }
    }
}