using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> List(int pageSize, int pageIndex);
        IEnumerable<Customer> List();
        Customer Get(int id);
        void Add(Customer customer);
        void Edit(int id, Customer customer);
        void Delete(int Id, Customer customer);
    }
}