using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HomePageVST.Filters
{
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        public int FileSize { get; set; }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            bool isValid = true;
            int allowedFileSize = FileSize;
            if (file != null)
            {
                var fileSize = file.ContentLength;
                isValid = fileSize <= allowedFileSize;
            }
            return isValid;
        }
    }
}