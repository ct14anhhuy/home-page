using Data;
using Repositories;

namespace Services
{
    public class CandidateService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Candidate> _candidateRepository;

        public CandidateService()
        {
            _unitOfWork = new UnitOfWork();
            _candidateRepository = _unitOfWork.CandidateRepository;
        }
    }
}