using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetActivedCustomers();

        CustomerDTO CreateCustomer(CustomerDTO customerDTO);

        void SetActiveCustomer(CustomerDTO customerDTO);

        CustomerDTO RemoveCustomer(int customerId);
    }
}