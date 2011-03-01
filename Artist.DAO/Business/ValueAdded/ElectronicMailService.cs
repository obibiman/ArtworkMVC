using System;
using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Implementations;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class ElectronicMailService : IElectronicMailService
    {
        private readonly IElectronicMailRepository _electronicMailRepository;

        public ElectronicMailService(IElectronicMailRepository electronicMailRepository)
        {
            _electronicMailRepository = electronicMailRepository;
        }

        public IEnumerable<ElectronicMail> List()
        {
            return _electronicMailRepository.List();
        }

        public ElectronicMail Get(int id)
        {
            return _electronicMailRepository.Get(id);
        }

        public void Add(int id, ElectronicMail electronicMail)
        {
            _electronicMailRepository.Add(id, electronicMail);
        }

        public void Edit(int id, ElectronicMail electronicMail)
        {
            _electronicMailRepository.Edit(id, electronicMail);
        }

        public void Delete(int id)
        {
            _electronicMailRepository.Delete(id);
        }
    }
}