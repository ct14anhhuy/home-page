using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HomePageVST.Filters
{
    public class AllowFileSizeAttribute : ValidationAttribute
    {
        public int FileSize { get; set; }

        public override bool IsValid(object value)
        {
            bool isValid = true;
            int allowedFileSize = FileSize;
            if (value is HttpPostedFileBase file)
            {
                var fileSize = file.ContentLength;
                isValid = fileSize <= allowedFileSize;
            }
            return isValid;
        }
    }
}