using AutoMapper;
using Data;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class JobSkillService : IJobSkillService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<JobSkill> _jobSkillRepository;
        private IMapper _mapper;

        public JobSkillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jobSkillRepository = _unitOfWork.JobSkillRepository;
            _mapper = mapper;
        }
    }
}