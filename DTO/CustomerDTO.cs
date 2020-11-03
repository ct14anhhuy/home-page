using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your company name")]
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Enter your company address")]
        [Display(Name = "CompanyAddress")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Enter your telephone")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Actived { get; set; }

        [IgnoreMap]
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}