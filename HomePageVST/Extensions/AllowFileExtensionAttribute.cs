using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace HomePageVST.Filters
{
    public class AllowFileExtensionAttribute : ValidationAttribute
    {
        public string FileExtension { get; set; }

        public override bool IsValid(object value)
        {
            bool isValid = true;
            if (value is HttpPostedFileBase file)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                isValid = fileExtension == FileExtension;
            }
            return isValid;
        }
    }
}