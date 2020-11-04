using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter description")]
        [Display(Name = "Description")]
        public string ImageDescription { get; set; }

        public string FilePath { get; set; }
        public string MinimalFilePath { get; set; }

        [Required(ErrorMessage = "Enter uploaded date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Uploaded Date")]
        public DateTime? DatePosted { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Enter actived")]
        [Display(Name = "Actived")]
        public bool IsActive { get; set; } = true;

        #region IgnoreMap

        [IgnoreMap]
        [Display(Name = "Image File")]
        public virtual HttpPostedFileBase ImageFile { get; set; }

        #endregion IgnoreMap

        public int? HeaderDetailId { get; set; }

        public virtual HeaderDetailDTO HeaderDetail { get; set; }
    }
}