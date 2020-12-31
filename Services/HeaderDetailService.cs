using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class HeaderDetailService : IHeaderDetailService
    {
        private readonly IGenericRepository<HeaderDetail> _headerDetailRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HeaderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _headerDetailRepository = _unitOfWork.HeaderDetailRepository;
            _mapper = mapper;
        }

        public IEnumerable<HeaderDetailDTO> GetMenus()
        {
            var listHeaderDetail = _headerDetailRepository.GetAll(c => c.HeaderCategory);
            return _mapper.Map<IEnumerable<HeaderDetailDTO>>(listHeaderDetail);
        }

        public IEnumerable<HeaderDetailDTO> GetUrls()
        {
            IEnumerable<HeaderDetail> listHeaderDetail = _headerDetailRepository.GetMany(h => h.Alias != null);
            return _mapper.Map<IEnumerable<HeaderDetailDTO>>(listHeaderDetail);
        }
    }
}