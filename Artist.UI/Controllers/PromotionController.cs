using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artist.DAO.Implementations;
using Artist.DAO.EntityFrameWork;
using Artist.UI.ViewModels;

namespace Artist.UI.Controllers
{
    public class PromotionController : Controller
    {
        private readonly PromotionRepository _repository;

        public PromotionController()
        {
            _repository = new PromotionRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Promotion> promotions = _repository.List();
            var promotionViewModels = new List<PromotionViewModel>();
            foreach (Promotion promotion in promotions)
            {
                var promotionViewModel = new PromotionViewModel()
                {
                    Id = promotion.Id,
                    ProductId = promotion.ProductId,
                    SalesStartDate = promotion.SalesStartDate,
                    SalesEndDate = promotion.SalesEndDate,
                    PercentDiscount = promotion.PercentDiscount,
                    ModifiedDate = promotion.ModifiedDate
                };
                promotionViewModels.Add(promotionViewModel);
            }
            return promotions.Count() > 0 ? View(promotionViewModels) : View("No data found");
        }

        public ActionResult Details(int id)
        {
            Promotion promotion = _repository.Get(id);
            var promotionViewModel = new PromotionViewModel
            {
                Id = promotion.Id,
                ProductId = promotion.ProductId,
                SalesStartDate = promotion.SalesStartDate,
                SalesEndDate = promotion.SalesEndDate,
                PercentDiscount = promotion.PercentDiscount,
                ModifiedDate = promotion.ModifiedDate
            };

            return promotionViewModel.Id > 0 ? View(promotionViewModel) : View("No data found");
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int productId, Promotion promotion)
        {
            try
            {
                _repository.Add(productId, promotion);
                var promotionViewModel = new PromotionViewModel
                {
                    Id = promotion.Id,
                    ProductId = promotion.ProductId,
                    SalesStartDate = promotion.SalesStartDate,
                    SalesEndDate = promotion.SalesEndDate,
                    PercentDiscount = promotion.PercentDiscount,
                    ModifiedDate = promotion.ModifiedDate
                };
                return RedirectToAction("Index", promotionViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var promotion = _repository.Get(id);
            var promotionViewModel = new PromotionViewModel
            {
                Id = promotion.Id,
                ProductId = promotion.ProductId,
                SalesStartDate = promotion.SalesStartDate,
                SalesEndDate = promotion.SalesEndDate,
                PercentDiscount = promotion.PercentDiscount,
                ModifiedDate = promotion.ModifiedDate
            };
            return View(promotionViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, Promotion promotion)
        {
            try
            {
                _repository.Edit(id, promotion);
                var promotionViewModel = new PromotionViewModel
                {
                    Id = promotion.Id,
                    ProductId = promotion.ProductId,
                    SalesStartDate = promotion.SalesStartDate,
                    SalesEndDate = promotion.SalesEndDate,
                    PercentDiscount = promotion.PercentDiscount,
                    ModifiedDate = promotion.ModifiedDate
                };
                return RedirectToAction("Index", promotionViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int Id, Promotion promotion)
        {
            try
            {
                Promotion promotionToDelete = _repository.Get(Id);
                _repository.Delete(Id, promotionToDelete);

                var promotionViewModel = new PromotionViewModel
                {
                    Id = promotion.Id,
                    ProductId = promotion.ProductId,
                    SalesStartDate = promotion.SalesStartDate,
                    SalesEndDate = promotion.SalesEndDate,
                    PercentDiscount = promotion.PercentDiscount,
                    ModifiedDate = promotion.ModifiedDate
                };
                return RedirectToAction("Index", promotionViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}