using AutoMapper;
using Data;
using DTO;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class HeaderCategoryService
    {
        private GenericRepository<HeaderCategory> _headerCategoryRepository;
        private UnitOfWork _unitOfWork;

        public HeaderCategoryService()
        {
            _unitOfWork = new UnitOfWork();
            _headerCategoryRepository = _unitOfWork.HeaderCategoryRepository;
        }

        public IEnumerable<HeaderCategoryDTO> GetAll()
        {
            IEnumerable<HeaderCategory> listHeaderCategory = _headerCategoryRepository.GetAll();
            return Mapper.Map<IEnumerable<HeaderCategoryDTO>>(listHeaderCategory);
        }
    }
}