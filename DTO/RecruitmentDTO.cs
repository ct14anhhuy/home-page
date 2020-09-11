using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RecruitmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter job title")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Enter job job description")]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Enter job requirement")]
        [Display(Name = "Job Requirement")]
        public string JobRequirement { get; set; }

        public string Salary { get; set; }

        [Display(Name = "Date Posted")]
        [Required(ErrorMessage = "Enter date posted")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DatePosted { get; set; }

        [Display(Name = "Date Expired")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateExpired { get; set; }

        [Display(Name = "Actived")]
        public bool IsActive { get; set; }

        public virtual ICollection<BenefitDTO> Benefits { get; set; }
        public virtual ICollection<CandidateDTO> Candidates { get; set; }
        public virtual ICollection<JobSkillDTO> JobSkills { get; set; }
    }
}