using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Business.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> List(int pageSize, int pageIndex);
        IEnumerable<Customer> List();
        Customer Get(int id);
        void Add(Customer customer);
        void Edit(int id, Customer customer);
        void Delete(int Id, Customer customer);
    }
}