using Domain.Entities;
using System.Diagnostics.Metrics;

namespace Application.Interfaces
{
    public interface ICourierService
    {
        Guid CreateCourier(string name, string phoneNumber);
        List<Courier> GetAllCouriers();
        Courier GetCourierById(Guid id);
        void UpdateCourier(Guid id, string name, string phoneNumber);
        void DeleteCourier(Guid id);
    }
}
