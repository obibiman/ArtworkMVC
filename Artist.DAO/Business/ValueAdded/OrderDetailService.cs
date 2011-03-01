using System;
using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Implementations;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> List()
        {
            return _orderDetailRepository.List();
        }

        public OrderDetail Get(int id)
        {
            return _orderDetailRepository.Get(id);
        }

        public void Add(int orderId, OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderId, orderDetail);
        }

        public void Edit(int orderDetailId, OrderDetail orderDetail)
        {
            _orderDetailRepository.Edit(orderDetailId, orderDetail);
        }

        public void Delete(int id)
        {
            _orderDetailRepository.Delete(id);
        }

        public decimal GetOrderTotal(int orderId)
        {
            return _orderDetailRepository.GetOrderTotal(orderId);
        }
    }
}