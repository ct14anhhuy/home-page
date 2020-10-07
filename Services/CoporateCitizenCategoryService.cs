using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class CoporateCitizenCategoryService : ICoporateCitizenCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<CoporateCitizenCategory> _coporateCitizenCategory;
        private IMapper _mapper;

        public CoporateCitizenCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _coporateCitizenCategory = _unitOfWork.CoporateCitizenCategoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CoporateCitizenCategoryDTO> GetAll()
        {
            var listCategory = _coporateCitizenCategory.GetAll();
            return _mapper.Map<IEnumerable<CoporateCitizenCategoryDTO>>(listCategory);
        }
    }
}