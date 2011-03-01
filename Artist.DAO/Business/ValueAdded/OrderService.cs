using System;
using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> List()
        {
            return _orderRepository.List();
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public void Add(int customerId, Order order)
        {
            _orderRepository.Add(customerId, order);
        }

        public void Edit(int orderId, Order order)
        {
            _orderRepository.Edit(orderId, order);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}