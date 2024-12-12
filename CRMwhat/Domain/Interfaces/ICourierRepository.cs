using Domain.Entities;
using System.Diagnostics.Metrics;

namespace Domain.Interfaces
{
    public interface ICourierRepository
    {
        Courier GetById(Guid id);
        List<Courier> GetAll();
        void Add(Courier courier);
        void Update(Courier courier);
        void Delete(Guid id);
    }
}
