using System.Web;
using DTO;
using HomePageVST.Filters;
using System.ComponentModel.DataAnnotations;

namespace HomePageVST.Models
{
    public class DocumentViewModel : DocumentDTO
    {
        [AllowFileSize(FileSize = 10 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 10 MB")]
        [AllowFileExtension(FileExtension = ".pdf", ErrorMessage = "Extension of file upload must be pdf")]
        [Display(Name = "Pdf Name")]
        public override HttpPostedFileBase PdfFile { get; set; }
    }
}