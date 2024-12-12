using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        List<Customer> GetAll(); // ����� ��� ��������� ���� ��������
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
    }
}
