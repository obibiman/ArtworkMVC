using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class ElectronicMailController : Controller
    {
        private readonly ElectronicMailRepository _repository;
        //
        // GET: /Customer/
        public ElectronicMailController()
        {
            _repository = new ElectronicMailRepository();
        }

        //
        // GET: /Address/

        public ActionResult Index()
        {
            IEnumerable<ElectronicMail> electronicMails = _repository.List();
            List<ElectronicMailViewModel> lstAvm = electronicMails.Select(electronicMail => new ElectronicMailViewModel
                                                                                                {
                                                                                                    Id =
                                                                                                        electronicMail.
                                                                                                        Id,
                                                                                                    CustomerId =
                                                                                                        electronicMail.
                                                                                                        CustomerId,
                                                                                                    Email =
                                                                                                        electronicMail.
                                                                                                        Email,
                                                                                                    IsPrimary =
                                                                                                        electronicMail.
                                                                                                        IsPrimary,
                                                                                                    ModifiedDate =
                                                                                                        electronicMail.
                                                                                                        ModifiedDate
                                                                                                }).ToList();

            return lstAvm.Count() > 0 ? View(lstAvm) : View("No data found");
        }

        //
        // GET: /ElectronicMail/Details/5

        public ActionResult Details(int id)
        {
            ElectronicMail electronicMail = _repository.Get(id);
            var toDisplay = new ElectronicMailViewModel
                                {
                                    Id = electronicMail.Id,
                                    CustomerId = electronicMail.CustomerId,
                                    Email = electronicMail.Email,
                                    IsPrimary = electronicMail.IsPrimary,
                                    ModifiedDate = electronicMail.ModifiedDate
                                };
            return toDisplay.Id > 0 ? View(toDisplay) : View("No data found");
        }

        //
        // GET: /ElectronicMail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ElectronicMail/Create

        [HttpPost]
        public ActionResult Create(int customerId, ElectronicMail electronicMail)
        {
            try
            {
                _repository.Add(customerId, electronicMail);
                var emailViewModel = new ElectronicMailViewModel
                                         {
                                             Id = electronicMail.Id,
                                             CustomerId = electronicMail.CustomerId,
                                             Email = electronicMail.Email,
                                             IsPrimary = electronicMail.IsPrimary,
                                             ModifiedDate = electronicMail.ModifiedDate
                                         };
                return RedirectToAction("Index", emailViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ElectronicMail/Edit/5

        public ActionResult Edit(int id)
        {
            ElectronicMail electronicMail = _repository.Get(id);
            var emailViewModel = new ElectronicMailViewModel
                                     {
                                         Id = electronicMail.Id,
                                         CustomerId = electronicMail.CustomerId,
                                         Email = electronicMail.Email,
                                         IsPrimary = electronicMail.IsPrimary,
                                         ModifiedDate = electronicMail.ModifiedDate
                                     };
            return View(emailViewModel);
        }

        //
        // POST: /ElectronicMail/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ElectronicMail electronicMail)
        {
            try
            {
                _repository.Edit(id, electronicMail);
                var emailViewModel = new ElectronicMailViewModel
                                         {
                                             Id = electronicMail.Id,
                                             CustomerId = electronicMail.CustomerId,
                                             Email = electronicMail.Email,
                                             IsPrimary = electronicMail.IsPrimary,
                                             ModifiedDate = electronicMail.ModifiedDate
                                         };
                return RedirectToAction("Index", emailViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ElectronicMail/Delete/5

        public ActionResult Delete(int id)
        {
            ElectronicMail electronicMail = _repository.Get(id);
            var emailViewModel = new ElectronicMailViewModel
                                     {
                                         Id = electronicMail.Id,
                                         CustomerId = electronicMail.CustomerId,
                                         Email = electronicMail.Email,
                                         IsPrimary = electronicMail.IsPrimary,
                                         ModifiedDate = electronicMail.ModifiedDate
                                     };
            return View(emailViewModel);
        }

        //
        // POST: /ElectronicMail/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, ElectronicMail electronicMail)
        {
            try
            {
                ElectronicMail toDelete = _repository.Get(id);
                _repository.Delete(id);
                var emailViewModel = new ElectronicMailViewModel
                                         {
                                             Id = electronicMail.Id,
                                             CustomerId = toDelete.CustomerId,
                                             Email = toDelete.Email,
                                             IsPrimary = toDelete.IsPrimary,
                                             ModifiedDate = toDelete.ModifiedDate
                                         };
                return RedirectToAction("Index", emailViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}