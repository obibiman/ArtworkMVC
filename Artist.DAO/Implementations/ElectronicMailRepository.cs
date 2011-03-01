using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class ElectronicMailRepository : IElectronicMailRepository
    {
        private readonly KarenEntities _dataContext;

        public ElectronicMailRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IElectronicMailRepository Members

        public void Delete(int id)
        {
            ElectronicMail entityToEdit = (from cust in _dataContext.ElectronicMails
                                           where cust.Id == id
                                           select cust).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }

        #endregion

        public IEnumerable<ElectronicMail> List()
        {
            List<ElectronicMail> electronicMails = (from electronicMail in _dataContext.ElectronicMails
                                                    orderby electronicMail.CustomerId descending
                                                    select electronicMail).ToList();
            return electronicMails;
        }

        public ElectronicMail Get(int id)
        {
            ElectronicMail electronicMail =
                (from eMail in _dataContext.ElectronicMails where eMail.Id == id select eMail).FirstOrDefault();
            return electronicMail;
        }

        public void Add(int customerId, ElectronicMail electronicMail)
        {
            if (CanOverrideIncomingEmail(customerId))
            {
                electronicMail.IsPrimary = true;
            }

            var addr = new ElectronicMail
                           {
                               CustomerId = customerId,
                               Email = electronicMail.Email,
                               IsPrimary = electronicMail.IsPrimary,
                               ModifiedDate = DateTime.Now
                           };

            //update other values of email isPrimary, if necessary
            UpdatePreviouslyDefinedprimaryEmails(customerId);
            _dataContext.ElectronicMails.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, ElectronicMail electronicMail)
        {
            ElectronicMail entityToEdit = (from cust in _dataContext.ElectronicMails
                                           where cust.Id == id
                                           select cust).FirstOrDefault();

            if (CanOverrideIncomingEmail(entityToEdit.CustomerId))
            {
                electronicMail.IsPrimary = true;
            }

            entityToEdit.IsPrimary = electronicMail.IsPrimary;
            entityToEdit.Email = electronicMail.Email;
            entityToEdit.ModifiedDate = DateTime.Now;

            UpdatePreviouslyDefinedprimaryEmails(entityToEdit.CustomerId);
            _dataContext.SaveChanges();
        }

        private bool CanOverrideIncomingEmail(int customerId)
        {
            bool updateIncoming = false;
            int countNonPrimary =
                (from p in _dataContext.ElectronicMails
                 where p.CustomerId == customerId && p.IsPrimary == false
                 select p).Count();

            int countPrimary =
                (from p in _dataContext.ElectronicMails
                 where p.CustomerId == customerId
                 select p).Count();
            if (countNonPrimary == countPrimary)
            {
                updateIncoming = true;
            }
            return updateIncoming;
        }

        private void UpdatePreviouslyDefinedprimaryEmails(int customerId)
        {
            List<ElectronicMail> lstEmails =
                (from p in _dataContext.ElectronicMails where p.CustomerId == customerId && p.IsPrimary select p)
                    .ToList();

            UpdatePreviousPrimaries(lstEmails);
        }

        private void UpdatePreviousPrimaries(List<ElectronicMail> lstEmails)
        {
            if (lstEmails.Count > 0)
            {
                foreach (ElectronicMail electronicMail in lstEmails)
                {
                    electronicMail.IsPrimary = false;
                    electronicMail.ModifiedDate = DateTime.Now;
                    _dataContext.SaveChanges();
                }
            }
        }
    }
}