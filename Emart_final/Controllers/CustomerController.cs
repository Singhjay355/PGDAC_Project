using Emart_final.Models;
using Emart_final.Repository.Customerfolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Emart_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomers();

            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById_ActionResultOfT(int id)
        {
            var customer = await _repository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var addedCustomer = await _repository.AddCustomer(customer);
            return CreatedAtAction(nameof(GetById_ActionResultOfT), new { id = addedCustomer.custId }, addedCustomer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.custId)
            {
                return BadRequest();
            }

            try
            {
                var updatedCustomer = await _repository.UpdateCustomer(id, customer);

                if (updatedCustomer == null)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repository.GetCustomer(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerToDelete = await _repository.GetCustomer(id);

            if (customerToDelete == null)
            {
                return NotFound();
            }

            await _repository.DeleteCustomer(id);
            return NoContent();
        }
    }
}
