using Domain.ValueObjects;

namespace Domain.Entities
{
    public class DeliveryRoute
    {
        public Guid Id { get; private set; }
        public List<Address> Addresses { get; private set; }
        public Guid AssignedCourierId { get; private set; }

        public DeliveryRoute(Guid assignedCourierId, List<Address> addresses)
        {
            Id = Guid.NewGuid();
            AssignedCourierId = assignedCourierId;
            Addresses = addresses ?? new List<Address>();
        }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        public void RemoveAddress(Address address)
        {
            Addresses.Remove(address);
        }
    }
}
