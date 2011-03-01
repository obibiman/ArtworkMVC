using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailRepository _repository;
        //
        // GET: /Customer/
        public OrderDetailController()
        {
            _repository = new OrderDetailRepository();
        }

        //
        // GET: /Address/

        public ActionResult Index()
        {
            IEnumerable<OrderDetail> orderDetails = _repository.List();
            List<OrderDetailViewModel> lstAvm = orderDetails.Select(orderDetail => new OrderDetailViewModel
                                                                                       {
                                                                                           OrderDetailId =
                                                                                               orderDetail.Id,
                                                                                           OrderId = orderDetail.OrderId,
                                                                                           ProductId =
                                                                                               orderDetail.ProductId,
                                                                                           Quantity =
                                                                                               orderDetail.Quantity,
                                                                                           UnitPrice =
                                                                                               orderDetail.UnitPrice,
                                                                                               LineItemTotal = orderDetail.Quantity * orderDetail.UnitPrice,
                                                                                           ModifiedDate =
                                                                                               orderDetail.ModifiedDate
                                                                                       }).ToList();

            return lstAvm.Count() > 0 ? View(lstAvm) : View("No data found");
        }

        //
        // GET: /OrderDetail/Details/5

        public ActionResult Details(int id)
        {
            OrderDetail orderDetail = _repository.Get(id);
            var toDisplay = new OrderDetailViewModel
                                {
                                    OrderDetailId = orderDetail.Id,
                                    OrderId = orderDetail.OrderId,
                                    ProductId = orderDetail.ProductId,
                                    Quantity = orderDetail.Quantity,
                                    UnitPrice = orderDetail.UnitPrice,
                                    LineItemTotal = orderDetail.Quantity * orderDetail.UnitPrice,
                                    ModifiedDate = orderDetail.ModifiedDate
                                };
            return toDisplay.OrderDetailId > 0 ? View(toDisplay) : View("No data found");
        }

        //
        // GET: /OrderDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderDetail/Create

        [HttpPost]
        public ActionResult Create(int orderId, OrderDetail orderDetail)
        {
            try
            {
                _repository.Add(orderId, orderDetail);
                var orderDetailViewModel = new OrderDetailViewModel
                                               {
                                                   OrderDetailId = orderDetail.Id,
                                                   OrderId = orderId,
                                                   ProductId = orderDetail.ProductId,
                                                   UnitPrice = orderDetail.UnitPrice,
                                                   Quantity = orderDetail.Quantity,
                                                   LineItemTotal = orderDetail.Quantity * orderDetail.UnitPrice,
                                                   ModifiedDate = orderDetail.ModifiedDate
                                               };
                return RedirectToAction("Index", orderDetailViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrderDetail/Edit/5

        public ActionResult Edit(int id)
        {
            OrderDetail orderDetail = _repository.Get(id);
            var orderDetailViewModel = new OrderDetailViewModel
                                           {
                                               OrderDetailId = orderDetail.Id,
                                               OrderId = orderDetail.OrderId,
                                               ProductId = orderDetail.ProductId,
                                               Quantity = orderDetail.Quantity,
                                               UnitPrice = orderDetail.UnitPrice,
                                               LineItemTotal = orderDetail.Quantity * orderDetail.UnitPrice,
                                               ModifiedDate = orderDetail.ModifiedDate
                                           };
            return View(orderDetailViewModel);
        }

        //
        // POST: /OrderDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, OrderDetail orderDetail)
        {
            try
            {
                _repository.Edit(id, orderDetail);
                var orderDetailViewModel = new OrderDetailViewModel
                                               {
                                                   OrderDetailId = orderDetail.Id,
                                                   OrderId = orderDetail.OrderId,
                                                   ProductId = orderDetail.ProductId,
                                                   Quantity = orderDetail.Quantity,
                                                   UnitPrice = orderDetail.UnitPrice,
                                                   LineItemTotal = orderDetail.Quantity * orderDetail.UnitPrice,
                                                   ModifiedDate = orderDetail.ModifiedDate
                                               };
                return RedirectToAction("Index", orderDetailViewModel);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /OrderDetail/Delete/5

        public ActionResult Delete(int id)
        {
            OrderDetail toDelete = _repository.Get(id);
            var orderDetailViewModel = new OrderDetailViewModel
                                           {
                                               OrderDetailId = toDelete.Id,
                                               OrderId = toDelete.OrderId,
                                               ProductId = toDelete.ProductId,
                                               Quantity = toDelete.Quantity,
                                               UnitPrice = toDelete.UnitPrice,
                                               LineItemTotal = toDelete.Quantity * toDelete.UnitPrice,
                                               ModifiedDate = toDelete.ModifiedDate
                                           };
            return View(orderDetailViewModel);
        }

        //
        // POST: /OrderDetail/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, OrderDetail orderDetail)
        {
            try
            {
                OrderDetail toDelete = _repository.Get(id);
                _repository.Delete(id);
                var orderDetailViewModel = new OrderDetailViewModel
                                               {
                                                   OrderDetailId = orderDetail.Id,
                                                   OrderId = orderDetail.OrderId,
                                                   ProductId = toDelete.ProductId,
                                                   Quantity = toDelete.Quantity,
                                                   UnitPrice = toDelete.UnitPrice,
                                                   LineItemTotal = toDelete.Quantity * toDelete.UnitPrice,
                                                   ModifiedDate = toDelete.ModifiedDate
                                               };
                return RedirectToAction("Index", orderDetailViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}