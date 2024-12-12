using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Guid CreateCustomer(string name, string email, string phoneNumber, string address)
        {
            var customer = new Customer(name, phoneNumber, email);
            customer.UpdateContactInformation(phoneNumber, email); // Если нужно
            _customerRepository.Add(customer);
            return customer.Id;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _customerRepository.GetById(id);
        }

        public void UpdateCustomer(Guid id, string name, string email, string phoneNumber, string address)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) throw new ArgumentException("Customer not found");

            customer.UpdateContactInformation(phoneNumber, email);
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            _customerRepository.Delete(id);
        }
    }
}
