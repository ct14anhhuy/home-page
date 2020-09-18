using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IImageService
    {
        IEnumerable<ImageDTO> GetAll();

        IEnumerable<ImageDTO> GetImagesByHeaderDetailId(int headerDetailId);

        IEnumerable<ImageDTO> GetActiveImagesByHeaderDetailId(int headerDetailId);

        ImageDTO GetImageByHeaderDetailId(int headerDetailId);

        ImageDTO Add(ImageDTO imageDTO);

        void Edit(ImageDTO imageDTO);

        ImageDTO Delete(int imageId);
    }
}