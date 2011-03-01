using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Domain;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class TelephoneController : Controller
    {
        private readonly TelephoneRepository _repository;
        //
        // GET: /Customer/
        public TelephoneController()
        {
            _repository = new TelephoneRepository();
        }

        //
        // GET: /Telephone/

        public ActionResult Index()
        {
            IEnumerable<Telephone> lstTelephone = _repository.List();

            List<TelephoneViewModel> lstAvm = lstTelephone.Select(telephone => new TelephoneViewModel
                                                                                   {
                                                                                       Id = telephone.Id,
                                                                                       CustomerId = telephone.CustomerId,
                                                                                       PhoneNumber =
                                                                                           telephone.PhoneNumber,
                                                                                       IsPrimary = telephone.IsPrimary,
                                                                                       ModifiedDate =
                                                                                           telephone.ModifiedDate
                                                                                   }).ToList();

            return lstAvm.Count() > 0 ? View(lstAvm) : View("No data found");
        }

        public ActionResult Details(int id)
        {
            Telephone telephone = _repository.Get(id);
            var toDisplay = new TelephoneViewModel
                                {
                                    Id = telephone.Id,
                                    CustomerId = telephone.CustomerId,
                                    PhoneNumber = telephone.PhoneNumber,
                                    IsPrimary = telephone.IsPrimary,
                                    ModifiedDate = telephone.ModifiedDate
                                };
            return toDisplay.Id > 0 ? View(toDisplay) : View("No data found");
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int customerId, Telephone telephone)
        {
            try
            {
                _repository.Add(customerId, telephone);
                var telephoneToDisplay = new TelephoneViewModel
                                             {
                                                 CustomerId = customerId,
                                                 Id = telephone.Id,
                                                 PhoneNumber = telephone.PhoneNumber,
                                                 IsPrimary = telephone.IsPrimary,
                                                 ModifiedDate = telephone.ModifiedDate
                                             };

                return RedirectToAction("Index", telephoneToDisplay);
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            Telephone telephone = _repository.Get(id);

            var custToDisplay = new TelephoneViewModel
                                    {
                                        Id = telephone.Id,
                                        CustomerId = telephone.CustomerId,
                                        PhoneNumber = telephone.PhoneNumber,
                                        IsPrimary = telephone.IsPrimary,
                                        ModifiedDate = telephone.ModifiedDate
                                    };
            return View(custToDisplay);
        }

        //
        // POST: /Telephone/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Telephone telephone)
        {
            try
            {
                _repository.Edit(id, telephone);
                var telephoneToDisplay = new TelephoneViewModel
                                             {
                                                 Id = telephone.Id,
                                                 CustomerId = telephone.CustomerId,
                                                 PhoneNumber = telephone.PhoneNumber,
                                                 IsPrimary = telephone.IsPrimary,
                                                 ModifiedDate = telephone.ModifiedDate
                                             };
                return RedirectToAction("Index", telephoneToDisplay);
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Customer for Dropdown List

        public ActionResult PhoneDropdown()
        {
            var viewModel = new CustomerDropdownViewModel();
            IEnumerable<CustomerToken> lstCustomerInfo = _repository.GetCustomerToken();
            viewModel.SelectedCustomers = lstCustomerInfo.Select(x => new SelectListItem
                                                                          {
                                                                              Text = x.TokenName,
                                                                              Value = x.TokenId.ToString(),
                                                                              Selected =
                                                                                  String.IsNullOrEmpty(
                                                                                      x.TokenId.ToString())
                                                                                      ? false
                                                                                      : true
                                                                          });
            return View(viewModel);
        }

        #endregion

        #region Customer for Dropdown List User Control

        public ActionResult DropdownUC()
        {
            var viewModel = new CustomerDropdownViewModel();
            IEnumerable<CustomerToken> lstCustomerInfo = _repository.GetCustomerToken();

            viewModel.SelectedCustomers = lstCustomerInfo.Select(x => new SelectListItem
                                                                          {
                                                                              Text = x.TokenName,
                                                                              Value = x.TokenId.ToString(),
                                                                              Selected =
                                                                                  String.IsNullOrEmpty(
                                                                                      x.TokenId.ToString())
                                                                                      ? false
                                                                                      : true
                                                                          });
            return View(viewModel);
        }

        #endregion
    }
}