using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customerDTO)
        {
            byte[] salt = CryptoService.GenerateSalt();
            string verifyEmail = ConfigHelper.ReadSetting("VerifyEmail");
            customerDTO.PasswordSalt = Convert.ToBase64String(salt);
            customerDTO.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(customerDTO.Password, salt));
            var customer = _customerRepository.Add(_mapper.Map<Customer>(customerDTO));
            _unitOfWork.Commit();
            await SendMailToEmployee(customer, verifyEmail, "Hello Ms.Nguyet", "http://www.poscovst.com.vn/Admin/Customer/VerifyCustomer/", "Verify");
            return _mapper.Map<CustomerDTO>(customer);
        }

        public bool CheckLogin(string email, string password)
        {
            bool verify = false;
            var customer = _customerRepository.GetSingle(x => x.Email == email && x.IsActive);
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
            if (customer.IsActive && !customer.IsVerify)
            {
                throw new Exception("Can not uncheck Verifed when Active checked");
            }
            _customerRepository.Update(_mapper.Map<Customer>(customer), x => x.CompanyAddress, x => x.CompanyName, x => x.IsActive, x => x.Telephone);
            _unitOfWork.Commit(validateOnSaveEnabled: false);
        }

        public async Task<bool> ApprovalCustomer(int id)
        {
            bool result = false;
            var customer = _customerRepository.GetSingle(c => c.Id == id && !c.IsActive);
            if (customer != null)
            {
                customer.IsActive = true;
                _customerRepository.Update(customer, x => x.IsActive);
                _unitOfWork.Commit(validateOnSaveEnabled: false);
                await SendMailToCustomer(customer);
                result = true;
            }
            return result;
        }

        public async Task<bool> VerifyCustomer(int id)
        {
            bool result = false;
            string approvalEmail = ConfigHelper.ReadSetting("ApprovalEmail");
            var customer = _customerRepository.GetSingle(c => c.Id == id && !c.IsVerify);
            if (customer != null)
            {
                customer.IsVerify = true;
                _customerRepository.Update(customer, c => c.IsVerify);
                _unitOfWork.Commit(validateOnSaveEnabled: false);
                await SendMailToEmployee(customer, approvalEmail, "Hello Mr.Thai", "http://www.poscovst.com.vn/Admin/Customer/ApprovalCustomer/", "Approval");
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
            return _customerRepository.GetSingle(c => c.Email == email) != null;
        }

        public bool ChangePassword(string email, string password, string newPassword)
        {
            bool checkError = false;
            bool verify = false;
            var customer = _customerRepository.GetSingle(x => x.Email == email && x.IsActive);
            if (customer != null)
            {
                verify = CryptoService.VerifyPassword(password, Convert.FromBase64String(customer.PasswordHash), Convert.FromBase64String(customer.PasswordSalt));
                if (verify)
                {
                    byte[] salt = CryptoService.GenerateSalt();
                    customer.PasswordSalt = Convert.ToBase64String(salt);
                    customer.PasswordHash = Convert.ToBase64String(CryptoService.ComputeHash(newPassword, salt));
                    _customerRepository.Update(customer, c => c.PasswordHash, c => c.PasswordSalt);
                    _unitOfWork.Commit(validateOnSaveEnabled: false);
                    checkError = true;
                }
            }
            return checkError;
        }

        private async Task SendMailToEmployee(Customer customer, string email, string empName, string route, string action)
        {
            string templatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.ReadSetting("Template.Email.Path");
            string content = "";
            StringBuilder body = new StringBuilder();
            body.AppendLine("<p>This's info of a new customer from www.poscovst.com.vn website.</p>");
            body.AppendLine("<table border='0' cellpadding='1' cellspacing='1' style='width: unset;>'");
            body.AppendLine("<tr>");
            body.AppendLine("<td><strong>Email</strong></td>");
            body.AppendLine($"<td>: {customer.Email}</td>");
            body.AppendLine("</tr>");
            body.AppendLine("<tr>");
            body.AppendLine("<td><strong>Company name</strong></td>");
            body.AppendLine($"<td>: {customer.CompanyName}</td>");
            body.AppendLine("</tr>");
            body.AppendLine("<tr>");
            body.AppendLine("<td><strong>Company address</strong></td>");
            body.AppendLine($"<td>: {customer.CompanyAddress}</td>");
            body.AppendLine("</tr>");
            body.AppendLine("<tr>");
            body.AppendLine("<td><strong>Telephone</strong></td>");
            body.AppendLine($"<td>: {customer.Telephone}</td>");
            body.AppendLine("</tr>");
            body.AppendLine("</table>");
            body.AppendLine($"<p>You can click the button below to {action.ToLower()} for this customer.</p>");
            using (StreamReader sr = new StreamReader(templatePath))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            content = content.Replace("[receiver]", empName);
            content = content.Replace("[emailBody]", body.ToString());
            content = content.Replace("[action]", action);
            content = content.Replace("[link]", $"{route}{customer.Id}");
            await EmailService.SendEmail(email, $"[{action}][{customer.CompanyName}] New customer request from www.poscovst.com.vn", content);
        }

        private async Task SendMailToCustomer(Customer customer)
        {
            string templatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigHelper.ReadSetting("Template.Email.Path");
            string receiver = "Dear Mr/Mrs";
            string content = "";
            StringBuilder body = new StringBuilder();
            body.AppendLine("<p>Thank you for contact to us.</p>");
            body.AppendLine("<p>We would like to inform you that your email has been successfully actived.</p>");
            body.AppendLine("<p>Should you have any question, please do not hesitate to contact us.</p>");
            using (StreamReader sr = new StreamReader(templatePath))
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            content = content.Replace("[receiver]", receiver);
            content = content.Replace("[emailBody]", body.ToString());
            content = content.Replace("[action]", "Visit us");
            content = content.Replace("[link]", "http://www.poscovst.com.vn");
            await EmailService.SendEmail(customer.Email, "[Posco VST] Your account has been approved", content);
        }
    }
}