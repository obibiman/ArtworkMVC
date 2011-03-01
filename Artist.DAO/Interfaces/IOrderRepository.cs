using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> List();
        Order Get(int id);
        void Add(int customerId, Order order);
        void Edit(int orderId, Order order);
        void Delete(int id);
    }
}