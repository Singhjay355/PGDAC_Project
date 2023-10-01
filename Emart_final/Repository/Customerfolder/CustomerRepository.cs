using Emart_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Emart_final.Repository.Customerfolder
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteCustomer(int Id)
        {
            Customer customer = await context.Customers.FindAsync(Id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
                return customer; 
            }
            return null; 
        }


        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetCustomer(int Id)
        {
            var customer = await context.Customers.FindAsync(Id);
            return customer;
        }

        public async Task<Customer?> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.custId)
            {
                return null;
            }

            context.Entry(customer).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return customer;
        }

        private bool CustomerExists(int id)
        {
            return context.Customers?.Any(e => e.custId == id) ?? false;
        }
    }
}

