using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateCustomer(CustomerDTO customerDTO);

        bool CheckLogin(string email, string password);

        IEnumerable<CustomerDTO> GetAll();

        CustomerDTO GetById(int id);

        void Edit(CustomerDTO customer);

        CustomerDTO Delete(int id);

        Task<bool> VerifyCustomer(int id);

        Task<bool> ApprovalCustomer(int id);

        bool GetCustomerByEmail(string email);

        bool ChangePassword(string email, string password, string newPassword);
    }
}