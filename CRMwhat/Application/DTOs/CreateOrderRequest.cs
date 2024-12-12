namespace Application.DTOs
{
    public class CreateOrderRequest
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemDTO> Items { get; set; }

        public CreateOrderRequest()
        {
            Items = new List<OrderItemDTO>();
        }
    }

    public class OrderItemDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
