using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IMapper _mapper;
        private const int IMAGE_QUALITY = 1024;
        private const int THUMBNAIL_QUALITY = 300;
        private const int IMAGES_PER_PAGE = 10;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = _unitOfWork.ImageRepository;
            _mapper = mapper;
        }

        public IEnumerable<ImageDTO> GetActiveImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetMany(i => i.HeaderDetailId == headerDetailId && i.IsActive);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetAll()
        {
            var images = _imageRepository.GetAll();
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public ImageDTO Add(ImageDTO imageDTO)
        {
            string fileName = $"{DateTime.Now:yyyyMMddhhmmss}-{imageDTO.ImageFile.FileName.ConvertToUnsignAndRemoveEmpty()}";
            string imgFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.Read("Image.News.Path") + fileName;
            string thumbFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.Read("Thumbnail.News.Path") + fileName;

            //Save image
            ImageHelper.PerformImageResize(imageDTO.ImageFile, IMAGE_QUALITY, 0, imgFilePath);
            //Save thumbnail
            ImageHelper.PerformImageResize(imageDTO.ImageFile, THUMBNAIL_QUALITY, 0, thumbFilePath);

            imageDTO.FilePath = ConfigHelper.Read("Image.News.Path") + fileName;
            imageDTO.MinimalFilePath = ConfigHelper.Read("Thumbnail.News.Path") + fileName;
            var image = _imageRepository.Add(_mapper.Map<Image>(imageDTO));
            _unitOfWork.Commit();
            return _mapper.Map<ImageDTO>(image);
        }

        public void Edit(ImageDTO imageDTO)
        {
            _imageRepository.Update(_mapper.Map<Image>(imageDTO));
            _unitOfWork.Commit();
        }

        public ImageDTO Delete(int imageId)
        {
            var image = _imageRepository.Delete(imageId);
            _unitOfWork.Commit();
            return _mapper.Map<ImageDTO>(image);
        }

        public ImageDTO GetImageByHeaderDetailId(int headerDetailId)
        {
            var image = _imageRepository.GetSingleById(headerDetailId);
            return _mapper.Map<ImageDTO>(image);
        }

        public IEnumerable<ImageDTO> GetImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetMany(i => i.HeaderDetailId == headerDetailId);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetRandomImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetRandom(i => i.HeaderDetailId == headerDetailId, IMAGES_PER_PAGE);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }
    }
}