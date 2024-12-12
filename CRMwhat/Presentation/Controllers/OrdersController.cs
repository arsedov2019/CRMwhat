using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            var orderId = _orderService.CreateOrder(request);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            // Логика получения заказа по ID через сервис
            return Ok(); // Добавьте вызов метода GetById из сервиса
        }

        [HttpPut("{id}/cancel")]
        public IActionResult CancelOrder(Guid id)
        {
            _orderService.CancelOrder(id);
            return NoContent();
        }
    }
}
