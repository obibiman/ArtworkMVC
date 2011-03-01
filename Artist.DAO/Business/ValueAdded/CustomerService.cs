using System;
using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> List(int pageSize, int pageIndex)
        {
            return _customerRepository.List(pageSize, pageIndex);
        }

        public IEnumerable<Customer> List()
        {
            return _customerRepository.List();
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void Edit(int id, Customer customer)
        {
            _customerRepository.Edit(id, customer);
        }

        public void Delete(int Id, Customer customer)
        {
             _customerRepository.Delete(Id, customer);
        }
    }
}