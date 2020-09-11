using System;

namespace DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateApplied { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public string CVName { get; set; }
        public string CVPath { get; set; }
        public int RecruitmentId { get; set; }

        public virtual RecruitmentDTO Recruitment { get; set; }
    }
}