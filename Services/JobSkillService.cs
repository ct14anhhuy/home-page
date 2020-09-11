using Data;
using Repositories;

namespace Services
{
    public class JobSkillService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<JobSkill> _jobSkillRepository;

        public JobSkillService()
        {
            _unitOfWork = new UnitOfWork();
            _jobSkillRepository = _unitOfWork.JobSkillRepository;
        }
    }
}