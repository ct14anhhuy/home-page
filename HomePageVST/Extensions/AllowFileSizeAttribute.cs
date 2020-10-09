using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HomePageVST.Filters
{
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        public int FileSize { get; set; } = 100 * 1024 * 1024;
        public override bool IsValid(object value)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;
            int allowedFileSize = this.FileSize;
            if (file != null)
            {
                var fileSize = file.ContentLength;
                isValid = fileSize <= allowedFileSize;
            }
            return isValid;
        }
    }
}