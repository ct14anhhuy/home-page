using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Customer> _customerRepository;
        private IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = _unitOfWork.CustomerRepository;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDTO> GetActivedCustomers()
        {
            var customers = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            byte[] salt = CryptoService.GenerateSalt();
            customerDTO.PasswordSalt = Convert.ToBase64String(salt);
            customerDTO.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(customerDTO.Password, salt));
            var customer = _customerRepository.Add(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
            return _mapper.Map<CustomerDTO>(customer);
        }

        public void SetActiveCustomer(CustomerDTO customerDTO)
        {
            _customerRepository.Update(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
        }

        public CustomerDTO RemoveCustomer(int customerId)
        {
            var customer = _customerRepository.Delete(customerId);
            _unitOfWork.Commit();
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}