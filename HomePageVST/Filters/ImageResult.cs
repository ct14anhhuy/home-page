using System;
using System.IO;
using System.Web.Mvc;

namespace HomePageVST.Filters
{
    public class ImageResult : ActionResult
    {
        public Stream ImageStream { get; set; }
        public string ContentType { get; set; }

        public ImageResult(Stream imageStream, string contentType)
        {
            if (imageStream == null)
            {
                throw new ArgumentNullException("imageStream");
            }
            if (contentType == null)
            {
                throw new ArgumentNullException("contentType");
            }
            this.ImageStream = imageStream;
            this.ContentType = contentType;
        }


        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var response = context.HttpContext.Response;
            response.ContentType = this.ContentType;
            byte[] buffer = new byte[4096];
            while (true)
            {
                int read = this.ImageStream.Read(buffer, 0, buffer.Length);
                if (read == 0)
                {
                    break;
                }
                response.OutputStream.Write(buffer, 0, read);
            }
            response.End();
        }
    }
}