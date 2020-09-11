using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class HeaderCategoryService : IHeaderCategoryService
    {
        private IGenericRepository<HeaderCategory> _headerCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public HeaderCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _headerCategoryRepository = _unitOfWork.HeaderCategoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<HeaderCategoryDTO> GetAll()
        {
            IEnumerable<HeaderCategory> listHeaderCategory = _headerCategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<HeaderCategoryDTO>>(listHeaderCategory);
        }
    }
}