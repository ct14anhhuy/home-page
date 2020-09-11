using AutoMapper;
using Data;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Role> _roleRepository;
        private IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = _unitOfWork.RoleRepository;
            _mapper = mapper;
        }
    }
}