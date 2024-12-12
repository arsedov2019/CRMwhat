using Application.DTOs;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Guid CreateOrder(CreateOrderRequest request);
        void AssignRouteToOrder(Guid orderId, Guid routeId);
        void CancelOrder(Guid orderId);
        void MarkOrderAsDelivered(Guid orderId);
    }
}
