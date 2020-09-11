using Data;
using Repositories;

namespace Services
{
    public class RoleService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Role> _roleRepository;

        public RoleService()
        {
            _unitOfWork = new UnitOfWork();
            _roleRepository = _unitOfWork.RoleRepository;
        }
    }
}