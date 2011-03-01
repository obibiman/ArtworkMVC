using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly KarenEntities _dataContext;

        public OrderDetailRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IOrderDetailRepository Members

        public void Delete(int id)
        {
            OrderDetail entityToEdit = (from orderDetail in _dataContext.OrderDetails
                                        where orderDetail.Id == id
                                        select orderDetail).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }

        public decimal GetOrderTotal(int orderId)
        {
            decimal orderTotal = 0;
            var orderLineItem = (from orderDetail in _dataContext.OrderDetails
                                 where orderDetail.OrderId == orderId
                                 select new {OrderTotal = orderDetail.Quantity*orderDetail.UnitPrice});

            foreach (var lineItem in orderLineItem)
            {
                orderTotal = orderTotal + (decimal) lineItem.OrderTotal;
            }
            return orderTotal;
        }

        #endregion

        public IEnumerable<OrderDetail> List()
        {
            List<OrderDetail> orderDetails = (from orderDetail in _dataContext.OrderDetails
                                              orderby orderDetail.Id descending
                                              select orderDetail).ToList();
            return orderDetails;
        }

        public OrderDetail Get(int id)
        {
            OrderDetail orderDetail =
                (from detail in _dataContext.OrderDetails where detail.Id == id select detail).FirstOrDefault();
            return orderDetail;
        }


        public void Add(int orderId, OrderDetail orderDetail)
        {
            var productPricingRepository = new ProductPricingRepository();

            var addr = new OrderDetail
                           {
                               OrderId = orderId,
                               ProductId = orderDetail.ProductId,
                               Quantity = orderDetail.Quantity,
                               UnitPrice = productPricingRepository.GetPricing(orderDetail.ProductId),
                               ModifiedDate = DateTime.Now
                           };

            _dataContext.OrderDetails.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, OrderDetail orderDetail)
        {
            var productPricingRepository = new ProductPricingRepository();
            OrderDetail entityToEdit = (from cust in _dataContext.OrderDetails
                                        where cust.Id == id
                                        select cust).FirstOrDefault();

            entityToEdit.ProductId = orderDetail.ProductId;
            entityToEdit.Quantity = orderDetail.Quantity;
            entityToEdit.UnitPrice = productPricingRepository.GetPricing(orderDetail.ProductId);
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }
    }
}