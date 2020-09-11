using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IHeaderCategoryService
    {
        IEnumerable<HeaderCategoryDTO> GetAll();
    }
}
