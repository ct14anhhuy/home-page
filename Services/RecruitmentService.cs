using AutoMapper;
using Data;
using DTO;
using Repositories;
using System;
using System.Collections.Generic;

namespace Services
{
    public class RecruitmentService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Recruitment> _recruitmentRepository;

        public RecruitmentService()
        {
            _unitOfWork = new UnitOfWork();
            _recruitmentRepository = _unitOfWork.RecruitmentRepository;
        }

        public IEnumerable<RecruitmentDTO> GetAll()
        {
            var listRecruitment = _recruitmentRepository.GetAll();
            return Mapper.Map<IEnumerable<RecruitmentDTO>>(listRecruitment);
        }

        public RecruitmentDTO GetDetailByID(int id)
        {
            var recruitment = _recruitmentRepository.GetSingleById(id);
            return Mapper.Map<RecruitmentDTO>(recruitment);
        }

        public IEnumerable<RecruitmentDTO> GetActivedRecruitment()
        {
            var recruitments = _recruitmentRepository.GetMultiByPredicate(x => x.IsActive && x.DatePosted <= DateTime.Today && (x.DateExpired == null || x.DateExpired >= DateTime.Today));
            return Mapper.Map<IEnumerable<RecruitmentDTO>>(recruitments);
        }

        public RecruitmentDTO Add(RecruitmentDTO recruitmentDTO)
        {
            if (recruitmentDTO.DateExpired != null && recruitmentDTO.DateExpired < recruitmentDTO.DatePosted)
            {
                throw new Exception("Date expired can't small than date posted");
            }
            var recruitment = _recruitmentRepository.Add(Mapper.Map<Recruitment>(recruitmentDTO));
            _unitOfWork.Commit();
            return Mapper.Map<RecruitmentDTO>(recruitment);
        }

        public void Edit(RecruitmentDTO recruitmentDTO)
        {
            if (recruitmentDTO.DateExpired != null && recruitmentDTO.DateExpired < recruitmentDTO.DatePosted)
            {
                throw new Exception("Date expired can't small than date posted");
            }
            _recruitmentRepository.Update(Mapper.Map<Recruitment>(recruitmentDTO));
            _unitOfWork.Commit();
        }

        public RecruitmentDTO Delete(int id)
        {
            var recruitment = _recruitmentRepository.DeleteById(id);
            _unitOfWork.Commit();
            return Mapper.Map<RecruitmentDTO>(recruitment);
        }
    }
}