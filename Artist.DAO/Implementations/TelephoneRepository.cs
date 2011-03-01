using System;
using System.Collections.Generic;
using System.Text;
using Artist.DAO.Domain;
using Artist.DAO.Interfaces;
using Artist.DAO.EntityFrameWork;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class TelephoneRepository : ITelephoneRepository
    {
        private readonly KarenEntities _dataContext;

        public TelephoneRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region ITelephoneRepository Members

        public void Delete(int id)
        {
            Telephone entityToEdit = (from cust in _dataContext.Telephones
                                      where cust.Id == id
                                      select cust).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }

        #endregion

        public IEnumerable<Telephone> List()
        {
            List<Telephone> telephones = (from telephone in _dataContext.Telephones select telephone).ToList();
            //var getToken = GetCustomerToken();
            return telephones;
        }

        public Telephone Get(int id)
        {
            Telephone telephone =
                (from addr in _dataContext.Telephones where addr.Id == id select addr).FirstOrDefault();
            return telephone;
        }

        public void Add(int customerId, Telephone telephone)
        {
            var addr = new Telephone
                           {
                               CustomerId = customerId,
                               PhoneNumber = telephone.PhoneNumber,
                               IsPrimary = telephone.IsPrimary,
                               ModifiedDate = DateTime.Now
                           };
            _dataContext.Telephones.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int telephoneId, Telephone telephone)
        {
            Telephone entityToEdit = (from cust in _dataContext.Telephones
                                      where cust.Id == telephoneId
                                      select cust).FirstOrDefault();

            entityToEdit.IsPrimary = telephone.IsPrimary;
            entityToEdit.CustomerId = telephone.CustomerId;
            entityToEdit.IsPrimary = telephone.IsPrimary;
            entityToEdit.PhoneNumber = telephone.PhoneNumber;
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public List<CustomerToken> GetCustomerToken()
        {
            var customerProfiles = new List<CustomerToken>();
            //var telephones = (_dataContext.Customers.Select(telephone => new { telephone.FirstName, telephone.MI, telephone.LastName, telephone.Id })).ToList();
            var telephones =
                (_dataContext.Customers.Select(
                    telephone => new {telephone.FirstName, telephone.MI, telephone.LastName, telephone.Id}).OrderBy(
                        y => y.FirstName)).ToList();

            foreach (var telephone in telephones)
            {
                var sb = new StringBuilder();
                string customerName = String.IsNullOrEmpty(telephone.MI)
                                          ? sb.Append(telephone.FirstName).Append(" ").Append(telephone.LastName).
                                                ToString()
                                          : sb.Append(telephone.FirstName).Append(" ").Append(telephone.MI).Append(
                                              ". ").Append(telephone.LastName).ToString();
                var customerProfile = new CustomerToken
                                          {
                                              TokenId = telephone.Id,
                                              TokenName = customerName
                                          };
                customerProfiles.Add(customerProfile);
            }

            return customerProfiles;
        }

        //public List<CustomerProfile> GetCustomerDropDownInfo()
        //{
        //    var customerProfiles = new List<CustomerProfile>();
        //    var telephones = (_dataContext.Customers.Select(telephone => new { telephone.FirstName, telephone.MI, telephone.LastName, telephone.Id })).ToList();

        //    foreach (var telephone in telephones)
        //    {
        //        var sb = new StringBuilder();
        //        var customerName = String.IsNullOrEmpty(telephone.MI)
        //                           ? sb.Append(telephone.FirstName).Append(" ").Append(telephone.LastName).ToString()
        //                           : sb.Append(telephone.FirstName).Append(" ").Append(telephone.MI).Append(
        //                               ". ").Append(telephone.LastName).ToString();
        //        var customerProfile = new CustomerProfile
        //        {
        //            CustId = telephone.Id,
        //            CustName = customerName
        //        };
        //        customerProfiles.Add(customerProfile);
        //    }

        //    return customerProfiles;
        //}
    }
}