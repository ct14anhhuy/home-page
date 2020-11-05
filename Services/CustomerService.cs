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

        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            byte[] salt = CryptoService.GenerateSalt();
            customerDTO.PasswordSalt = Convert.ToBase64String(salt);
            customerDTO.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(customerDTO.Password, salt));
            var customer = _customerRepository.Add(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
            return _mapper.Map<CustomerDTO>(customer);
        }

        public bool CheckLogin(string email, string password)
        {
            bool verify = false;
            var customer = _customerRepository.GetSingleByPredicate(x => x.Email == email && x.IsActive);
            if (customer != null)
            {
                verify = CryptoService.VerifyPassword(password, Convert.FromBase64String(customer.PasswordHash), Convert.FromBase64String(customer.PasswordSalt));
            }
            return verify;
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO GetById(int id)
        {
            var customer = _customerRepository.GetSingleById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public void Edit(CustomerDTO customer)
        {
            _customerRepository.Update(_mapper.Map<Customer>(customer), x => x.CompanyAddress, x => x.CompanyName, x => x.IsActive, x => x.Telephone);
            _unitOfWork.Commit(validateOnSaveEnabled: false);
        }

        public CustomerDTO Delete(int id)
        {
            var customer = _customerRepository.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}