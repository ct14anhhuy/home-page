namespace DTO
{
    public class HeaderDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? HeaderCategoryId { get; set; }
        public int? ParentId { get; set; }

        public virtual HeaderCategoryDTO HeaderCategory { get; set; }
    }
}