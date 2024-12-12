using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Guid CreateCustomer(string name, string email, string phoneNumber, string address);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(Guid id);
        void UpdateCustomer(Guid id, string name, string email, string phoneNumber, string address);
        void DeleteCustomer(Guid id);
    }
}
