namespace DTO
{
    public class BenefitDTO
    {
        public int Id { get; set; }
        public string BenefitName { get; set; }
        public int RecruitmentId { get; set; }

        public virtual RecruitmentDTO Recruitment { get; set; }
    }
}