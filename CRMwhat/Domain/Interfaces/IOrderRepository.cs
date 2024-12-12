using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Guid id);
    }
}
