using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IImageService
    {
        IEnumerable<ImageDTO> GetAll();

        IEnumerable<ImageDTO> GetActiveImagesByHeaderDetailId(int headerDetailId);

        ImageDTO Add(ImageDTO imageDTO);

        void Edit(ImageDTO imageDTO);

        ImageDTO Delete(int imageId);
    }
}