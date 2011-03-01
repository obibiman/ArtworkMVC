using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressRepository _repository;
        //
        // GET: /Customer/
        public AddressController()
        {
            _repository = new AddressRepository();
        }

        //
        // GET: /Address/

        public ActionResult Index()
        {
            IEnumerable<Address> lstAddress = _repository.List();
            List<AddressViewModel> lstAvm = lstAddress.Select(address => new AddressViewModel
                                                                             {
                                                                                 Id = address.Id,
                                                                                 CustomerId = address.CustomerId,
                                                                                 Addr = address.Addr,
                                                                                 City = address.City,
                                                                                 State = address.State,
                                                                                 Zip = address.Zip,
                                                                                 IsPrimary = address.IsPrimary,
                                                                                 ModifiedDate = address.ModifiedDate
                                                                             }).ToList();

            return lstAvm.Count() > 0 ? View(lstAvm) : View("No data found");
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id)
        {
            Address address = _repository.Get(id);
            var toDisplay = new AddressViewModel
                                {
                                    Id = address.Id,
                                    CustomerId = address.CustomerId,
                                    Addr = address.Addr,
                                    City = address.City,
                                    State = address.State,
                                    Zip = address.Zip,
                                    IsPrimary = address.IsPrimary,
                                    ModifiedDate = address.ModifiedDate
                                };
            return toDisplay.Id > 0 ? View(toDisplay) : View("No data found");
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(int customerId, Address address)
        {
            try
            {
                _repository.Add(customerId, address);
                var addressToDisplay = new AddressViewModel
                                           {
                                               Id = address.Id,
                                               CustomerId = address.CustomerId,
                                               Addr = address.Addr,
                                               City = address.City,
                                               State = address.State,
                                               Zip = address.Zip,
                                               IsPrimary = address.IsPrimary,
                                               ModifiedDate = address.ModifiedDate
                                           };
                return RedirectToAction("Index", addressToDisplay);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id)
        {
            Address address = _repository.Get(id);
            var custToDisplay = new AddressViewModel
                                    {
                                        Id = address.Id,
                                        CustomerId = address.CustomerId,
                                        Addr = address.Addr,
                                        City = address.City,
                                        State = address.State,
                                        Zip = address.Zip,
                                        IsPrimary = address.IsPrimary,
                                        ModifiedDate = address.ModifiedDate
                                    };
            return View(custToDisplay);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                _repository.Edit(id, address);
                var addressToDisplay = new AddressViewModel
                                           {
                                               Id = address.Id,
                                               CustomerId = address.CustomerId,
                                               Addr = address.Addr,
                                               City = address.City,
                                               State = address.State,
                                               Zip = address.Zip,
                                               IsPrimary = address.IsPrimary,
                                               ModifiedDate = address.ModifiedDate
                                           };
                return RedirectToAction("Index", addressToDisplay);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id)
        {
            Address address = _repository.Get(id);
            var toDisplay = new AddressViewModel
                                {
                                    Id = address.Id,
                                    CustomerId = address.CustomerId,
                                    Addr = address.Addr,
                                    City = address.City,
                                    State = address.State,
                                    Zip = address.Zip,
                                    IsPrimary = address.IsPrimary,
                                    ModifiedDate = address.ModifiedDate
                                };
            return View(toDisplay);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Address address)
        {
            try
            {
                Address toDelete = _repository.Get(id);
                _repository.Delete(id);
                var toDisplay = new AddressViewModel
                                    {
                                        Id = address.Id,
                                        CustomerId = toDelete.CustomerId,
                                        Addr = toDelete.Addr,
                                        City = toDelete.City,
                                        State = toDelete.State,
                                        Zip = toDelete.Zip,
                                        IsPrimary = toDelete.IsPrimary,
                                        ModifiedDate = toDelete.ModifiedDate
                                    };
                return RedirectToAction("Index", toDisplay);
            }
            catch
            {
                return View();
            }
        }
    }
}