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
        private IGenericRepository<HeaderDetail> _HeaderDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public HeaderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _HeaderDetailRepository = _unitOfWork.HeaderDetailRepository;
            _mapper = mapper;
        }

        public IEnumerable<HeaderDetailDTO> GetAll()
        {
            IEnumerable<HeaderDetail> listHeaderDetail = _HeaderDetailRepository.GetAll();
            return _mapper.Map<IEnumerable<HeaderDetailDTO>>(listHeaderDetail);
        }
    }
}