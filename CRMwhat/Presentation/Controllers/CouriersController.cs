using Application.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouriersController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpPost]
        public IActionResult CreateCourier([FromBody] CreateCourierRequest request)
        {
            var courierId = _courierService.CreateCourier(request.Name, request.PhoneNumber);
            return CreatedAtAction(nameof(GetCourierById), new { id = courierId }, courierId);
        }

        [HttpGet]
        public IActionResult GetAllCouriers()
        {
            var couriers = _courierService.GetAllCouriers();
            return Ok(couriers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourierById(Guid id)
        {
            var courier = _courierService.GetCourierById(id);
            if (courier == null) return NotFound();
            return Ok(courier);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourier(Guid id, [FromBody] CreateCourierRequest request)
        {
            _courierService.UpdateCourier(id, request.Name, request.PhoneNumber);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourier(Guid id)
        {
            _courierService.DeleteCourier(id);
            return NoContent();
        }
    }
}
