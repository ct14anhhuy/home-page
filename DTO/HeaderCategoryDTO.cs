using System.Collections.Generic;

namespace DTO
{
    public class HeaderCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<HeaderDetailDTO> HeaderDetails { get; set; }
    }
}