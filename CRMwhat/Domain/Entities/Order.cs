using Domain.ValueObjects;
namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderStatus Status { get; private set; }
        public Guid? DeliveryRouteId { get; private set; }
        public Guid? PaymentId { get; private set; }

        public Order(Guid customerId, List<OrderItem> items)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Items = items ?? new List<OrderItem>();
            Status = OrderStatus.New;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        public void SetRoute(Guid routeId)
        {
            DeliveryRouteId = routeId;
            Status = OrderStatus.InProgress;
        }

        public void MarkAsDelivered()
        {
            Status = OrderStatus.Delivered;
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Canceled;
        }

        public void SetPayment(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }

    public class OrderItem
    {
        public Guid ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, decimal price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
