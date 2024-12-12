using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace Application.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;

        public CourierService(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public Guid CreateCourier(string name, string phoneNumber)
        {
            var courier = new Courier(name, phoneNumber);
            _courierRepository.Add(courier);
            return courier.Id;
        }

        public List<Courier> GetAllCouriers()
        {
            return _courierRepository.GetAll();
        }

        public Courier GetCourierById(Guid id)
        {
            return _courierRepository.GetById(id);
        }

        public void UpdateCourier(Guid id, string name, string phoneNumber)
        {
            var courier = _courierRepository.GetById(id);
            if (courier == null) throw new ArgumentException("Courier not found");

            courier.UpdateDetails(name, phoneNumber);
            _courierRepository.Update(courier);
        }

        public void DeleteCourier(Guid id)
        {
            _courierRepository.Delete(id);
        }
    }
}
