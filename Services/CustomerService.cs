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
            string adminEmail = ConfigHelper.ReadSetting("AdminEmail");
            customerDTO.PasswordSalt = Convert.ToBase64String(salt);
            customerDTO.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(customerDTO.Password, salt));
            var customer = _customerRepository.Add(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
            EmailService.SendEmail(adminEmail, $"[{customer.CompanyName}] New customer request from www.poscovst.com.vn", EmailToAdminContent(customer));
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
                EmailService.SendEmail(customer.Email, "[Posco VST] Your account has been approved", EmailToCustomerContent(customer.Email));
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

        public bool ChangePassword(string email, string password, string newPassword)
        {
            bool checkError = false;
            bool verify = false;
            var customer = _customerRepository.GetSingleByPredicate(x => x.Email == email && x.IsActive);
            if (customer != null)
            {
                verify = CryptoService.VerifyPassword(password, Convert.FromBase64String(customer.PasswordHash), Convert.FromBase64String(customer.PasswordSalt));
                if (verify)
                {
                    byte[] salt = CryptoService.GenerateSalt();
                    customer.PasswordSalt = Convert.ToBase64String(salt);
                    customer.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(newPassword, salt));
                    _customerRepository.Update(customer, c => c.PasswordHash, c => c.PasswordSalt);
                    _unitOfWork.Commit(false);
                    checkError = true;
                }
            }
            return checkError;
        }

        private string EmailToAdminContent(Customer customer)
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine($"<p>Hello Ms.Lan</p>");
            content.AppendLine($"<p>This's info of a new customer on www.poscovst.com.vn website</p>");
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
            content.AppendLine($"<p>You can check at admin page of www.poscovst.com.vn or&nbsp;click&nbsp;<a href='http://poscovst.com.vn/Admin/Customer/ApprovalCustomer/{customer.Id}' target='_blank'>HERE</a>&nbsp;to approval for this customer.</p>");
            return content.ToString();
        }

        private string EmailToCustomerContent(string customerEmail)
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine($"<p>Dear Mr/Mrs</p>");
            content.AppendLine($"<p>Thank you for contact to us.</p>");
            content.AppendLine($"<p>We would like to inform you that your email has been successfully actived.</p>");
            content.AppendLine($"<p>Should you have any question, please do not hesitate to contact us.</p>");
            content.AppendLine($"<p><b>Your sincerely</b></p>");
            content.AppendLine($"<p><b>Posco VST Vietnam</b></p>");
            content.AppendLine($"<p><b>Phone:</b> 0251-3560-360</p>");
            content.AppendLine($"<p><b>Email:</b> tran.phuonglan@posco.net</p>");
            content.AppendLine($"<p>* Please, do not reply this email.");
            return content.ToString();
        }
    }
}