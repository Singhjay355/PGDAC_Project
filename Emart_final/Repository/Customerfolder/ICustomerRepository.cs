using Microsoft.AspNetCore.Mvc;
using Emart_final.Models;

namespace Emart_final.Repository.Customerfolder
{
    public interface ICustomerRepository
    {

        Task<Customer> AddCustomer(Customer customer);
        Task<Customer?> DeleteCustomer(int Id);
        Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers();
        Task<Customer?> GetCustomer(int Id);
        Task<Customer?> UpdateCustomer(int id, Customer customer);

    }
}
