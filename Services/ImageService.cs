using System.Collections.Generic;
using DTO;
using Services.Interfaces;
using Repositories.Interfaces;
using AutoMapper;
using Data;

namespace Services
{
    public class ImageService : IImageService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Image> _imageRepository;
        private IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = _unitOfWork.ImageRepository;
            _mapper = mapper;
        }

        public IEnumerable<ImageDTO> GetImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetMultiByPredicate(i => i.HeaderDetailId == headerDetailId);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }
    }
}
