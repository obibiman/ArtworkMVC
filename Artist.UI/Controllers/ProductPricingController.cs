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
    public class ProductPricingController : Controller
    {
        private readonly ProductPricingRepository _repository;

        public ProductPricingController()
        {
            _repository = new ProductPricingRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<ProductPricing> productPricings = _repository.List();
            var productPricingViewModels = new List<ProductPricingViewModel>();
            foreach (ProductPricing productPricing in productPricings)
            {
                var productPricingViewModel = new ProductPricingViewModel()
                {
                    Id = productPricing.Id,
                    ProductId = productPricing.ProductId,
                    Price = productPricing.Price,
                    IsOnSale = productPricing.IsOnSale,
                    ModifiedDate = productPricing.ModifiedDate
                };
                productPricingViewModels.Add(productPricingViewModel);
            }
            return productPricings.Count() > 0 ? View(productPricingViewModels) : View("No data found");
        }

        public ActionResult Details(int id)
        {
            ProductPricing productPricing = _repository.Get(id);
            var productPricingViewModel = new ProductPricingViewModel
            {
                Id = productPricing.Id,
                ProductId = productPricing.ProductId,
                Price = productPricing.Price,
                IsOnSale = productPricing.IsOnSale,
                ModifiedDate = productPricing.ModifiedDate
            };

            return productPricingViewModel.Id > 0 ? View(productPricingViewModel) : View("No data found");
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int productId, ProductPricing productPricing)
        {
            try
            {
                _repository.Add(productId, productPricing);
                var productPricingViewModel = new ProductPricingViewModel
                {
                    Id = productPricing.Id,
                    ProductId = productPricing.ProductId,
                    Price = productPricing.Price,
                    IsOnSale = productPricing.IsOnSale,
                    ModifiedDate = productPricing.ModifiedDate
                };
                return RedirectToAction("Index", productPricingViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var productPricing = _repository.Get(id);
            var productPricingViewModel = new ProductPricingViewModel
            {
                Id = productPricing.Id,
                ProductId = productPricing.ProductId,
                Price = productPricing.Price,
                IsOnSale = productPricing.IsOnSale,
                ModifiedDate = productPricing.ModifiedDate
            };
            return View(productPricingViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, ProductPricing productPricing)
        {
            try
            {
                _repository.Edit(id, productPricing);
                var productPricingViewModel = new ProductPricingViewModel
                {
                    Id = productPricing.Id,
                    ProductId = productPricing.ProductId,
                    Price = productPricing.Price,
                    IsOnSale = productPricing.IsOnSale,
                    ModifiedDate = productPricing.ModifiedDate
                };
                return RedirectToAction("Index", productPricingViewModel);
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
        public ActionResult Delete(int Id, ProductPricing productPricing)
        {
            try
            {
                ProductPricing productPricingToDelete = _repository.Get(Id);
                _repository.Delete(Id, productPricingToDelete);

                var productPricingViewModel = new ProductPricingViewModel
                {
                    Id = productPricing.Id,
                    ProductId = productPricing.ProductId,
                    Price = productPricing.Price,
                    IsOnSale = productPricing.IsOnSale,
                    ModifiedDate = productPricing.ModifiedDate
                };
                return RedirectToAction("Index", productPricingViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}