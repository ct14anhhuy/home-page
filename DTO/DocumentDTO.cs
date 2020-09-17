using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DTO
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Enter description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter uploaded date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Uploaded Date")]
        public DateTime? UploadedDate { get; set; }

        [Required(ErrorMessage = "Enter actived")]
        [Display(Name = "Actived")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Enter file name")]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        #region IgnoreMap

        [IgnoreMap]
        [Display(Name = "Pdf File")]
        public virtual HttpPostedFileBase PdfFile { get; set; }

        #endregion IgnoreMap

        public virtual HeaderDetailDTO HeaderDetail { get; set; }
    }
}