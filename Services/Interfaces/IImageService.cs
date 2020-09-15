using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IImageService
    {
        IEnumerable<ImageDTO> GetImagesByHeaderDetailId(int headerDetailId);
    }
}
