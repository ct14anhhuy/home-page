using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CoporateCitizenContentService : ICoporateCitizenContentService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<CoporateCitizenContent> _coporateCitizenContent;
        private IMapper _mapper;

        public CoporateCitizenContentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _coporateCitizenContent = _unitOfWork.CoporateCitizenContentRepository;
            _mapper = mapper;
        }

        public CoporateCitizenContentDTO GetContentByCategoryId(int categoryId)
        {
            var content = _coporateCitizenContent.GetSingleByPredicate(c => c.CoporateCitizenCategoryId == categoryId, c => c.CoporateCitizenCategory);
            return _mapper.Map<CoporateCitizenContentDTO>(content);
        }
    }
}