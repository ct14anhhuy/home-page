using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IHeaderDetailService
    {
        IEnumerable<HeaderDetailDTO> GetAll();

        IEnumerable<HeaderDetailDTO> GetUrls();
    }
}