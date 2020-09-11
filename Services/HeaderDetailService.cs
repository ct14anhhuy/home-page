using AutoMapper;
using Data;
using DTO;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class HeaderDetailService
    {
        private GenericRepository<HeaderDetail> _HeaderDetailRepository;
        private UnitOfWork _unitOfWork;

        public HeaderDetailService()
        {
            _unitOfWork = new UnitOfWork();
            _HeaderDetailRepository = _unitOfWork.HeaderDetailRepository;
        }

        public IEnumerable<HeaderDetailDTO> GetAll()
        {
            IEnumerable<HeaderDetail> listHeaderDetail = _HeaderDetailRepository.GetAll();
            return Mapper.Map<IEnumerable<HeaderDetailDTO>>(listHeaderDetail);
        }
    }
}