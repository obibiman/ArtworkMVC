using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index(int pageIndex = 0)
        {
            const int pageSize = 5;
            IEnumerable<Customer> lstCustomer = _customerService.List(pageSize, pageIndex);
            List<CustomerViewModel> lstCvm = lstCustomer.Select(cust => new CustomerViewModel
                                                                            {
                                                                                Id = cust.Id,
                                                                                FirstName = cust.FirstName,
                                                                                CustomerName = cust.CustomerName,
                                                                                MI = cust.MI,
                                                                                LastName = cust.LastName,
                                                                                ModifiedDate = cust.ModifiedDate
                                                                            }).ToList();

            return lstCvm.Count() > 0 ? View(lstCvm) : View("No data found");
        }

        // GET: /Products/Paged?page=number&pageSize=number
        public ActionResult Paged(int page = 1, int pageSize = 8)
        {
            var model = new CustomerGridViewModel
                            {
                                CurrentPageIndex = page,
                                PageSize = pageSize
                            };
            IEnumerable<Customer> lstCustomer = _customerService.List();
            // Determine the total number of products being paged through (needed to compute PageCount)
            model.TotalRecordCount = lstCustomer.Count();
            model.Customers = lstCustomer
                .Skip((model.CurrentPageIndex - 1)*model.PageSize)
                .Take(model.PageSize);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _customerService.Get(id);
            var custToDisplay = new CustomerViewModel
                                    {
                                        Id = customer.Id,
                                        CustomerName = customer.CustomerName,
                                        FirstName = customer.FirstName,
                                        MI = customer.MI,
                                        LastName = customer.LastName,
                                        ModifiedDate = customer.ModifiedDate
                                    };
            return custToDisplay.Id > 0 ? View(custToDisplay) : View("No data found");
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.Add(customer);
                var custToDisplay = new CustomerViewModel
                                        {
                                            Id = customer.Id,
                                            FirstName = customer.FirstName,
                                            MI = customer.MI,
                                            LastName = customer.LastName,
                                            ModifiedDate = customer.ModifiedDate
                                        };
                return RedirectToAction("Index", custToDisplay);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            Customer customer = _customerService.Get(id);
            var custToDisplay = new CustomerViewModel
                                    {
                                        Id = customer.Id,
                                        FirstName = customer.FirstName,
                                        MI = customer.MI,
                                        LastName = customer.LastName,
                                        ModifiedDate = customer.ModifiedDate
                                    };
            return View(custToDisplay);
        }


        //POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                _customerService.Edit(id, customer);
                var custToDisplay = new CustomerViewModel
                                        {
                                            Id = customer.Id,
                                            FirstName = customer.FirstName,
                                            MI = customer.MI,
                                            LastName = customer.LastName,
                                            ModifiedDate = customer.ModifiedDate
                                        };
                return RedirectToAction("Index", custToDisplay);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            Customer customer = _customerService.Get(id);
            var custToDisplay = new CustomerViewModel
                                    {
                                        Id = customer.Id,
                                        FirstName = customer.FirstName,
                                        MI = customer.MI,
                                        LastName = customer.LastName,
                                        ModifiedDate = customer.ModifiedDate
                                    };
            return View(custToDisplay);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int Id, Customer customer)
        {
            try
            {
                Customer customerToDelete = _customerService.Get(Id);
                _customerService.Delete(Id, customerToDelete);
                var custToDisplay = new CustomerViewModel
                                        {
                                            Id = customer.Id,
                                            FirstName = customerToDelete.FirstName,
                                            MI = customerToDelete.MI,
                                            LastName = customerToDelete.LastName,
                                            ModifiedDate = customerToDelete.ModifiedDate
                                        };
                return RedirectToAction("Index", custToDisplay);
            }
            catch
            {
                return View();
            }
        }
    }
}