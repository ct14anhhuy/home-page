using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your company name")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Enter your company address")]
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Enter your telephone")]
        [Display(Name = "Telephone")]
        [Phone(ErrorMessage = "Invalid telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateCreated { get; set; } = DateTime.Today;

        [Display(Name = "Actived")]
        public bool IsActive { get; set; } = false;

        [Display(Name = "Verified")]
        public bool IsVerify { get; set; }

        #region IgnoreMap

        [IgnoreMap]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter your password")]
        [MinLength(6, ErrorMessage = "Password can't be less than 6 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [IgnoreMap]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password can't be less than 6 characters")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [IgnoreMap]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password can't be less than 6 characters")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match")]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }

        #endregion IgnoreMap
    }
}