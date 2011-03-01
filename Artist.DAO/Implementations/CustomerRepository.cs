using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly KarenEntities _dataContext;

        public CustomerRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region ICustomerRepository Members

        public IEnumerable<Customer> List()
        {
            List<Customer> customers = (from customer in _dataContext.Customers select customer).ToList();
            return customers;
        }

        public IEnumerable<Customer> List(int pageSize, int pageIndex = 0)
        {
            List<Customer> customers = _dataContext.Customers
                .OrderBy(c => c.Id)
                .Skip(pageIndex*pageSize)
                .Take(pageSize)
                .ToList();
            return customers;
        }

        public Customer Get(int id)
        {
            Customer customer = (from cust in _dataContext.Customers where cust.Id == id select cust).FirstOrDefault();
            return customer;
        }

        public void Add(Customer customer)
        {
            var cust = new Customer
                           {
                               Id = PrimaryKeyUtil.RandomNumber(1, 100903),
                               FirstName = customer.FirstName,
                               LastName = customer.LastName,
                               MI = customer.MI,
                               ModifiedDate = DateTime.Now
                           };
            _dataContext.Customers.AddObject(cust);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, Customer entity)
        {
            Customer entityToEdit = (from cust in _dataContext.Customers
                                     where cust.Id == id
                                     select cust).FirstOrDefault();

            entityToEdit.FirstName = entity.FirstName;
            entityToEdit.LastName = entity.LastName;
            entityToEdit.MI = entity.MI;
            entityToEdit.ModifiedDate = DateTime.Now;
            _dataContext.SaveChanges();
        }

        public void Delete(int Id, Customer cus)
        {
            Customer customerToDelete = (from cust in _dataContext.Customers.OfType<Customer>()
                                             .Include("Addresses")
                                             .Include("Telephones")
                                             .Include("ElectronicMails")
                                             .Include("Orders")
                                         where cust.Id == Id
                                         select cust).Single();

            List<Address> addressesToDelete = customerToDelete.Addresses.ToList();
            List<Telephone> telephonesToDelete = customerToDelete.Telephones.ToList();
            List<ElectronicMail> emailsToDelete = customerToDelete.ElectronicMails.ToList();
            List<Order> ordersTodelete = customerToDelete.Orders.ToList();

            foreach (Address r in addressesToDelete)
            {
                _dataContext.DeleteObject(r);
            }
            foreach (Telephone r in telephonesToDelete)
            {
                _dataContext.DeleteObject(r);
            }
            foreach (ElectronicMail r in emailsToDelete)
            {
                _dataContext.DeleteObject(r);
            }
            foreach (Order r in ordersTodelete)
            {
                _dataContext.DeleteObject(r);
            }

            _dataContext.DeleteObject(customerToDelete);
            _dataContext.SaveChanges();
        }

        #endregion
    }
}