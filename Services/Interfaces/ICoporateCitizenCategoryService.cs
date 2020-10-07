using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICoporateCitizenCategoryService
    {
        IEnumerable<CoporateCitizenCategoryDTO> GetAll();
    }
}