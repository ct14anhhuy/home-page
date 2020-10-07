using DTO;
using System.Collections.Generic;

namespace HomePageVST.Models
{
    public class CoporateCitizenViewModels
    {
        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<CoporateCitizenCategoryDTO> CoporateCitizenCategories { get; set; }
    }
}