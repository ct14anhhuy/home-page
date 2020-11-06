using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
            string toEmail = "anhhuy.le@posco.net";
            customerDTO.PasswordSalt = Convert.ToBase64String(salt);
            customerDTO.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(customerDTO.Password, salt));
            var customer = _customerRepository.Add(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
            EmailService.SendEmail(toEmail, EmailContent(customer));
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

        public bool ApprovalCustomer(int id)
        {
            bool result = false;
            var customer = _customerRepository.GetSingleByPredicate(c => c.Id == id && !c.IsActive);
            if (customer != null)
            {
                customer.IsActive = true;
                _customerRepository.Update(customer, x => x.IsActive);
                _unitOfWork.Commit(validateOnSaveEnabled: false);
                result = true;
            }
            return result;
        }

        public CustomerDTO Delete(int id)
        {
            var customer = _customerRepository.Delete(id);
            _unitOfWork.Commit();
            return _mapper.Map<CustomerDTO>(customer);
        }

        public bool GetCustomerByEmail(string email)
        {
            return _customerRepository.GetSingleByPredicate(c => c.Email == email) != null;
        }

        private string EmailContent(Customer customer)
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine($"<p>Hi.</p>");
            content.AppendLine("<table cellpadding='1' cellspacing='1' style='width: 500px'");
            content.AppendLine("<tbody>");
            content.AppendLine("<tr>");
            content.AppendLine("<td>Email</td>");
            content.AppendLine($"<td>: {customer.Email}</td>");
            content.AppendLine("</tr>");
            content.AppendLine("<tr>");
            content.AppendLine("<td>Company name</td>");
            content.AppendLine($"<td>: {customer.CompanyName}</td>");
            content.AppendLine("</tr>");
            content.AppendLine("<tr>");
            content.AppendLine("<td>Company address</td>");
            content.AppendLine($"<td>: {customer.CompanyAddress}</td>");
            content.AppendLine("</tr>");
            content.AppendLine("<tr>");
            content.AppendLine("<td>Telephone</td>");
            content.AppendLine($"<td>: {customer.Telephone}</td>");
            content.AppendLine("</tr>");
            content.AppendLine("</tbody>");
            content.AppendLine("</table>");
            content.AppendLine($"<p>You can check at admin page of poscovst.com.vn or&nbsp;click&nbsp;<a href='http://poscovst.com.vn/Admin/Customer/ApprovalCustomer/{customer.Id}' target='_blank'>HERE</a>&nbsp;to approval for this customer.</p>");
            return content.ToString();
        }
    }
}