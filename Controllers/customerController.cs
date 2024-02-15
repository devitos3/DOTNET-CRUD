using api2.Models;
using api2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customerController : ControllerBase
    {
        ICustomerServices _customerServices;

        public customerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_customerServices.GetCustomerById(id));

        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _customerServices.CreateCustomer(customer);
            return CreatedAtAction("Get", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            var existingCustomer = _customerServices.GetCustomerById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerServices.UpdateCustomer(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerServices.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerServices.DeleteCustomer(id);

            return NoContent();
        }

       


    }
}
