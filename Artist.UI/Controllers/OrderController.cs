using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _repository;
        //
        // GET: /Customer/
        public OrderController()
        {
            _repository = new OrderRepository();
        }

        //
        // GET: /Address/

        public ActionResult Index()
        {
            IEnumerable<Order> orders = _repository.List();
            List<OrderViewModel> orderViewModels = orders.Select(order => new OrderViewModel
                                                                              {
                                                                                  Id = order.Id,
                                                                                  CustomerId = order.CustomerId,
                                                                                  Amount = order.Amount,
                                                                                  ModifiedDate = order.ModifiedDate
                                                                              }).ToList();

            return orderViewModels.Count() > 0 ? View(orderViewModels) : View("No data found");
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            Order order = _repository.Get(id);
            var orderViewModel = new OrderViewModel
                                     {
                                         Id = order.Id,
                                         CustomerId = order.CustomerId,
                                         Amount = order.Amount,
                                         ModifiedDate = order.ModifiedDate
                                     };
            return orderViewModel.Id > 0 ? View(orderViewModel) : View("No data found");
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(int customerId, Order order)
        {
            try
            {
                _repository.Add(customerId, order);
                var orderViewModel = new OrderViewModel
                                         {
                                             Id = order.Id,
                                             CustomerId = order.CustomerId,
                                             Amount = order.Amount,
                                             ModifiedDate = order.ModifiedDate
                                         };
                return RedirectToAction("Index", orderViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            Order order = _repository.Get(id);
            var orderViewModel = new OrderViewModel
                                     {
                                         Id = order.Id,
                                         CustomerId = order.CustomerId,
                                         Amount = order.Amount,
                                         ModifiedDate = order.ModifiedDate
                                     };
            return View(orderViewModel);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                _repository.Edit(id, order);
                var orderViewModel = new OrderViewModel
                                         {
                                             Id = order.Id,
                                             CustomerId = order.CustomerId,
                                             Amount = order.Amount,
                                             ModifiedDate = order.ModifiedDate
                                         };
                return RedirectToAction("Index", orderViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            Order order = _repository.Get(id);
            var orderViewModel = new OrderViewModel
                                     {
                                         Id = order.Id,
                                         CustomerId = order.CustomerId,
                                         Amount = order.Amount,
                                         ModifiedDate = order.ModifiedDate
                                     };
            return View(orderViewModel);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                Order toDelete = _repository.Get(id);
                _repository.Delete(id);
                var orderViewModel = new OrderViewModel
                                         {
                                             Id = order.Id,
                                             CustomerId = toDelete.CustomerId,
                                             Amount = toDelete.Amount,
                                             ModifiedDate = toDelete.ModifiedDate
                                         };
                return RedirectToAction("Index", orderViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}