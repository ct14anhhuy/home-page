using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class RecruitmentService : IRecruitmentService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Recruitment> _recruitmentRepository;
        private IMapper _mapper;

        public RecruitmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _recruitmentRepository = _unitOfWork.RecruitmentRepository;
            _mapper = mapper;
        }

        public IEnumerable<RecruitmentDTO> GetAll()
        {
            var listRecruitment = _recruitmentRepository.GetAll();
            return _mapper.Map<IEnumerable<RecruitmentDTO>>(listRecruitment);
        }

        public RecruitmentDTO GetDetailByID(int id)
        {
            var recruitment = _recruitmentRepository.GetSingleById(id);
            return _mapper.Map<RecruitmentDTO>(recruitment);
        }

        public IEnumerable<RecruitmentDTO> GetActivedRecruitment()
        {
            var recruitments = _recruitmentRepository.GetMultiByPredicate(x => x.IsActive && x.DatePosted <= DateTime.Today && (x.DateExpired == null || x.DateExpired >= DateTime.Today));
            return _mapper.Map<IEnumerable<RecruitmentDTO>>(recruitments);
        }

        public RecruitmentDTO Add(RecruitmentDTO recruitmentDTO)
        {
            if (recruitmentDTO.DateExpired != null && recruitmentDTO.DateExpired < recruitmentDTO.DatePosted)
            {
                throw new Exception("Date expired can't small than date posted");
            }
            var recruitment = _recruitmentRepository.Add(_mapper.Map<Recruitment>(recruitmentDTO));
            _unitOfWork.Commit();
            return _mapper.Map<RecruitmentDTO>(recruitment);
        }

        public void Edit(RecruitmentDTO recruitmentDTO)
        {
            if (recruitmentDTO.DateExpired != null && recruitmentDTO.DateExpired < recruitmentDTO.DatePosted)
            {
                throw new Exception("Date expired can't small than date posted");
            }
            _recruitmentRepository.Update(_mapper.Map<Recruitment>(recruitmentDTO));
            _unitOfWork.Commit();
        }

        public RecruitmentDTO Delete(int id)
        {
            var recruitment = _recruitmentRepository.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<RecruitmentDTO>(recruitment);
        }
    }
}