using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Business.Interfaces
{
    public interface ITelephoneService
    {
        IEnumerable<Telephone> List();
        Telephone Get(int telephoneId);
        void Add(int customerId, Telephone telephone);
        void Edit(int telephoneId, Telephone telephone);
        void Delete(int id);
    }
}