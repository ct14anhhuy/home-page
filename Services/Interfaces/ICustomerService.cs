using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO CreateCustomer(CustomerDTO customerDTO);

        bool CheckLogin(string email, string password);

        IEnumerable<CustomerDTO> GetAll();

        CustomerDTO GetById(int id);

        void Edit(CustomerDTO customer);

        CustomerDTO Delete(int id);
    }
}