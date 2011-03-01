using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class AddressService : IAddressService
    {
        #region IAddressService Members

        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        public IEnumerable<Address> List()
        {

            return _addressRepository.List();
        }

        public Address Get(int id)
        {
            return _addressRepository.Get(id);
        }

        public void Add(int customerId, Address address)
        {
            _addressRepository.Add(customerId, address);
        }

        public void Edit(int id, Address address)
        {
            _addressRepository.Edit(id, address);
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        #endregion
    }
}