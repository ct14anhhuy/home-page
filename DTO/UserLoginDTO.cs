using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserLoginDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "UserName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "User name invalid, enter again")]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Today;
        public bool IsActive { get; set; } = true;

        #region IgnoreMap

        [IgnoreMap]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password can't be less than 6 characters")]
        [Required(ErrorMessage = "Enter your password")]
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

        public virtual RoleDTO Role { get; set; }
    }
}