using Data;
using Repositories;

namespace Services
{
    public class BenefitService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Benefit> _benefitRepository;

        public BenefitService()
        {
            _unitOfWork = new UnitOfWork();
            _benefitRepository = _unitOfWork.BenefitRepository;
        }
    }
}