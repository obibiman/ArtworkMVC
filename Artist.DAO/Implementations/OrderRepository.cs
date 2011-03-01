using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KarenEntities _dataContext;

        public OrderRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IOrderRepository Members

        public void Delete(int id)
        {
            Order entityToEdit = (from cust in _dataContext.Orders
                                  where cust.Id == id
                                  select cust).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }

        #endregion

        //public IEnumerable<Order> List()
        //{
        //    var orders = (from order in _dataContext.Orders
        //                  orderby order.CustomerId descending
        //                  select order).ToList();
        //    return orders;
        //}

        public IEnumerable<Order> List()
        {
            List<Order> orders = (from order in _dataContext.Orders
                                  orderby order.CustomerId descending
                                  select order).ToList();
            var orderDetailRepository = new OrderDetailRepository();
            IEnumerable<Order> orderList = new List<Order>();

            foreach (Order item in orders)
            {
                item.Amount = orderDetailRepository.GetOrderTotal(item.Id);
            }

            return orders;
        }

        public Order Get(int id)
        {
            Order order = (from ord in _dataContext.Orders where ord.Id == id select ord).FirstOrDefault();
            var orderDetailRepository = new OrderDetailRepository();
            order.Amount = orderDetailRepository.GetOrderTotal(order.Id);
            return order;
        }


        public void Add(int customerId, Order order)
        {
            var addr = new Order
                           {
                               CustomerId = customerId,
                               Amount = order.Amount,
                               ModifiedDate = DateTime.Now
                           };

            _dataContext.Orders.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, Order order)
        {
            Order entityToEdit = (from cust in _dataContext.Orders
                                  where cust.Id == id
                                  select cust).FirstOrDefault();

            entityToEdit.Amount = order.Amount;
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }
    }
}