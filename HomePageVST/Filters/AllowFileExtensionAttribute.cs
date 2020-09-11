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
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;
            if (file != null)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                isValid = fileExtension == this.FileExtension;
            }
            return isValid;
        }
    }
}