//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public System.DateTime DateApplied { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailConfirmed { get; set; }
        public Nullable<System.DateTime> DateConfirmed { get; set; }
        public string CVName { get; set; }
        public string CVPath { get; set; }
        public int RecruitmentId { get; set; }
    
        public virtual Recruitment Recruitment { get; set; }
    }
}