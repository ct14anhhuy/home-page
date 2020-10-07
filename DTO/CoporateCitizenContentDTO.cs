namespace DTO
{
    public  class CoporateCitizenContentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? CoporateCitizenCategoryId { get; set; }

        public virtual CoporateCitizenCategoryDTO CoporateCitizenCategory { get; set; }
    }
}
