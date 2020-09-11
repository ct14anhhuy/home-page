using AutoMapper;
using Data;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class CandidateService : ICandidateService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Candidate> _candidateRepository;
        private IMapper _mapper;

        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _candidateRepository = _unitOfWork.CandidateRepository;
            _mapper = mapper;
        }
    }
}