using Data;
using DTO;

namespace Services.Interfaces
{
    public interface ICoporateCitizenContentService
    {
        CoporateCitizenContentDTO GetContentByCategoryId(int categoryId);
    }
}