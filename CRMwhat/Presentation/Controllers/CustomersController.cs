using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var customerId = _customerService.CreateCustomer(request.Name, request.Email, request.PhoneNumber, request.Address);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] CreateCustomerRequest request)
        {
            _customerService.UpdateCustomer(id, request.Name, request.Email, request.PhoneNumber, request.Address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
