using System.Windows.Forms;
using WebCam_Capture;

namespace OpenShelf
{
    internal class Webcam
    {
        private PictureBox _FrameImage;
        private WebCamCapture _Webcam;

        public int FrameRate { get; set; }


        public void InitializeWebCam(ref PictureBox ImageControl)
        {
            FrameRate = 30;
            _Webcam = new WebCamCapture {FrameNumber = 0ul, TimeToCapture_milliseconds = FrameRate};
            _Webcam.ImageCaptured += WebcamImageCaptured;
            _FrameImage = ImageControl;
        }

        private void WebcamImageCaptured(object Source, WebcamEventArgs E)
        {
            _FrameImage.Image = E.WebCamImage;
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