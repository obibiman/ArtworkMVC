using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> List();
        OrderDetail Get(int id);
        void Add(int orderId, OrderDetail orderDetail);
        void Edit(int orderDetailId, OrderDetail orderDetail);
        void Delete(int id);
        decimal GetOrderTotal(int orderId);
    }
}