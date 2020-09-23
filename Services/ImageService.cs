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
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Image> _imageRepository;
        private IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = _unitOfWork.ImageRepository;
            _mapper = mapper;
        }

        public IEnumerable<ImageDTO> GetActiveImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetMultiByPredicate(i => i.HeaderDetailId == headerDetailId && i.IsActive);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetAll()
        {
            var images = _imageRepository.GetAll();
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public ImageDTO Add(ImageDTO imageDTO)
        {
            string fileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}-{imageDTO.ImageFile.FileName.ConvertToUnsignAndRemoveEmpty()}";
            string originFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.ReadSetting("image.News.Path") + fileName;
            string miniFilePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.ReadSetting("image.News.Mini.Path") + fileName;
            FileService.SaveFile(imageDTO.ImageFile, originFilePath);
            ImageHelper.PerformImageResize(originFilePath, 300, 0, miniFilePath);
            imageDTO.FilePath = ConfigHelper.ReadSetting("image.News.Path") + fileName;
            imageDTO.MinimalFilePath = ConfigHelper.ReadSetting("image.News.Mini.Path") + fileName;
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

            if (image != null)
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + image.FilePath;
                string minimalFilePath = AppDomain.CurrentDomain.BaseDirectory + image.MinimalFilePath;
                FileService.RemoveFile(filePath);
                FileService.RemoveFile(minimalFilePath);
            }

            return _mapper.Map<ImageDTO>(image);
        }

        public ImageDTO GetImageByHeaderDetailId(int headerDetailId)
        {
            var image = _imageRepository.GetSingleById(headerDetailId);
            return _mapper.Map<ImageDTO>(image);
        }

        public IEnumerable<ImageDTO> GetImagesByHeaderDetailId(int headerDetailId)
        {
            var images = _imageRepository.GetMultiByPredicate(i => i.HeaderDetailId == headerDetailId);
            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }
    }
}