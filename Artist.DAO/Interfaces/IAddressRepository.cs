using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> List();
        Address Get(int id);
        void Add(int id, Address address);
        void Edit(int id, Address address);
        void Delete(int id);
    }
}