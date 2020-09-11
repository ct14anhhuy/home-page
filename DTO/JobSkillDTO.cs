namespace DTO
{
    public class JobSkillDTO
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int RecruitmentId { get; set; }

        public virtual RecruitmentDTO Recruitment { get; set; }
    }
}