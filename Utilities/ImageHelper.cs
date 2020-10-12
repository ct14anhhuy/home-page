using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Utilities
{
    public static class ImageHelper
    {
        private static void SaveJpeg(string path, Image img)
        {
            var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
            var jpegCodec = GetEncoderInfo("image/jpeg");
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    img.Save(ms, jpegCodec, encoderParams);
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            return ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == mimeType);
        }

        private static Image Resize(Image image, int newWidth, int newHeight)
        {
            if (newHeight == 0)
            {
                var widthRatio = (float)newWidth / image.Width;
                newHeight = (int)(widthRatio * image.Height);
            }
            var res = new Bitmap(newWidth, newHeight);
            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return res;
        }

        public static void PerformImageResize(HttpPostedFileBase img, int newWidth, int newHeight, string filePath)
        {
            Image imgOrigin = Image.FromStream(img.InputStream);
            Image imgResized = Resize(imgOrigin, newWidth, newHeight);
            SaveJpeg(filePath, imgResized);
        }
    }
}