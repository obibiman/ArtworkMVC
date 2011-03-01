using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class TelephoneService : ITelephoneService
    {
        private readonly ITelephoneRepository _telephoneRepository;

        public TelephoneService(ITelephoneRepository telephoneRepository)
        {
            _telephoneRepository = telephoneRepository;
        }

        #region ITelephoneService Members

        public IEnumerable<Telephone> List()
        {
            return _telephoneRepository.List();
        }

        public Telephone Get(int telephoneId)
        {
            return _telephoneRepository.Get(telephoneId);
        }

        public void Add(int customerId, Telephone telephone)
        {
            _telephoneRepository.Add(customerId, telephone);
        }

        public void Edit(int telephoneId, Telephone telephone)
        {
            _telephoneRepository.Edit(telephoneId, telephone);
        }

        public void Delete(int id)
        {
            _telephoneRepository.Delete(id);
        }

        #endregion
    }
}