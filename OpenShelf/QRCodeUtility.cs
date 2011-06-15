using System;
using System.Collections;
using System.Drawing;
using com.google.zxing;
using com.google.zxing.common;

namespace OpenShelf
{
    internal static class QrCodeUtility
    {
        public static String Decode(Image Image)
        {
            try
            {
                var hints = new Hashtable();
                hints.Add(DecodeHintType.TRY_HARDER, true);
                ArrayList fmts = new ArrayList();
                fmts.Add(BarcodeFormat.QR_CODE);
                hints.Add(DecodeHintType.POSSIBLE_FORMATS, fmts);

                var Bitmap = new Bitmap(Image);
                LuminanceSource source = new RGBLuminanceSource(Bitmap, Bitmap.Width, Bitmap.Height);
                var bitmap = new BinaryBitmap(new GlobalHistogramBinarizer(source));
                Reader reader = new MultiFormatReader();
                Result result = reader.decode(bitmap, hints);
                String DecodedString = result.Text;
                Console.WriteLine(DecodedString);
                return DecodedString;
            }
            catch (ReaderException ex)
            {
                return "";
            }
            catch (InvalidOperationException ex)
            {
                return "";
            }
        }
    }
}