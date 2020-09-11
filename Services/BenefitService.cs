using AutoMapper;
using Data;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class BenefitService : IBenefitService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Benefit> _benefitRepository;
        private IMapper _mapper;

        public BenefitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _benefitRepository = _unitOfWork.BenefitRepository;
            _mapper = mapper;
        }
    }
}