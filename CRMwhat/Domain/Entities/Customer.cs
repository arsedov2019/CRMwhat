namespace Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Customer(string name, string phoneNumber, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void UpdateContactInformation(string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
