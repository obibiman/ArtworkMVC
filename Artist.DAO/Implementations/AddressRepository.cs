using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly KarenEntities _dataContext;

        public AddressRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IAddressRepository Members

        public IEnumerable<Address> List()
        {
            List<Address> addresses = (from address in _dataContext.Addresses select address).ToList();
            return addresses;
        }

        public Address Get(int id)
        {
            Address address = (from addr in _dataContext.Addresses where addr.Id == id select addr).FirstOrDefault();
            return address;
        }

        public void Add(int customerId, Address address)
        {
            var addr = new Address
                           {
                               CustomerId = customerId,
                               Addr = address.Addr,
                               City = address.City,
                               State = address.State,
                               Zip = address.Zip,
                               IsPrimary = address.IsPrimary,
                               ModifiedDate = DateTime.Now
                           };
            _dataContext.Addresses.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, Address address)
        {
            Address entityToEdit = (from cust in _dataContext.Addresses
                                    where cust.Id == id
                                    select cust).FirstOrDefault();

            entityToEdit.IsPrimary = address.IsPrimary;
            entityToEdit.Addr = address.Addr;
            entityToEdit.City = address.City;
            entityToEdit.State = address.State;
            entityToEdit.Zip = address.Zip;
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Address entityToEdit = (from cust in _dataContext.Addresses
                                    where cust.Id == id
                                    select cust).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }

        #endregion
    }
}