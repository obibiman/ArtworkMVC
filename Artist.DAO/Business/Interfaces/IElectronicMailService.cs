using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Business.Interfaces
{
    public interface IElectronicMailService
    {
        IEnumerable<ElectronicMail> List();
        ElectronicMail Get(int id);
        void Add(int id, ElectronicMail electronicMail);
        void Edit(int id, ElectronicMail electronicMail);
        void Delete(int id);
    }
}