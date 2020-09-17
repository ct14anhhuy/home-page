using DTO;
using HomePageVST.Filters;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HomePageVST.Models
{
    public class ImageViewModel : ImageDTO
    {
        [AllowFileSize(FileSize = 10 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 10 MB")]
        [Display(Name = "Image File")]
        public override HttpPostedFileBase ImageFile { get; set; }
    }
}