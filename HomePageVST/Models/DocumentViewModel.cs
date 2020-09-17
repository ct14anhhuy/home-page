using System.Web;
using DTO;
using HomePageVST.Filters;
using System.ComponentModel.DataAnnotations;

namespace HomePageVST.Models
{
    public class DocumentViewModel : DocumentDTO
    {
        [AllowFileSize(FileSize = 10 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 10 MB")]
        [AllowFileExtension(FileExtension = ".pdf", ErrorMessage = "File upload extension must be pdf")]
        [Display(Name = "Pdf File")]
        public override HttpPostedFileBase PdfFile { get; set; }
    }
}