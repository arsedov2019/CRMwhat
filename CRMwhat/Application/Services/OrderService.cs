using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public Guid CreateOrder(CreateOrderRequest request)
        {
            // Проверяем, существует ли клиент
            var customer = _customerRepository.GetById(request.CustomerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            // Создаём объекты OrderItem для каждого продукта
            var orderItems = new List<OrderItem>();
            foreach (var item in request.Items)
            {
                // Пример: здесь мы можем проверить существование продукта в базе данных
                orderItems.Add(new OrderItem(item.ProductId, 10, item.Quantity)); // Упрощённая логика
            }

            // Создаём заказ и сохраняем его через репозиторий
            var order = new Order(request.CustomerId, orderItems);
            _orderRepository.Add(order);
            return order.Id;
        }

        public void AssignRouteToOrder(Guid orderId, Guid routeId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                throw new ArgumentException("Order not found");

            order.SetRoute(routeId);
            _orderRepository.Update(order);
        }

        public void CancelOrder(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                throw new ArgumentException("Order not found");

            order.CancelOrder();
            _orderRepository.Update(order);
        }

        public void MarkOrderAsDelivered(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                throw new ArgumentException("Order not found");

            order.MarkAsDelivered();
            _orderRepository.Update(order);
        }
    }
}
