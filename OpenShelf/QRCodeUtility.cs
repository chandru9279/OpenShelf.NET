using System;
using System.Drawing;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace OpenShelf
{
    class QrCodeUtility
    {
        public void Decode()
        {
            try
            {
                QRCodeDecoder Decoder = new QRCodeDecoder();
                String DecodedString = Decoder.decode(new QRCodeBitmapImage(new Bitmap(picDecode.Image)));
                return DecodedString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
