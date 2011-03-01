using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;
using System.Linq;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Implementations
{
    public class ProductPricingRepository : IProductPricingRepository
    {
        private readonly KarenEntities _dataContext;

        public ProductPricingRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IProductPricingRepository Members

        public decimal GetPricing(int productId)
        {
            var productPrice = (from prodPrice in _dataContext.ProductPricings
                                where prodPrice.ProductId == productId
                                select prodPrice.Price).SingleOrDefault();
            var promotionRepository = new PromotionRepository();
            var isOnSale =
                (from pricing in _dataContext.ProductPricings
                 where pricing.ProductId == productId
                 select pricing.IsOnSale).FirstOrDefault();
            if (isOnSale)
            {
                productPrice = promotionRepository.GetPromotionPricing(productId, productPrice);
            }
            //var productPrice = (_dataContext.ProductPricings.Where(prodPrice => prodPrice.Id == productId).Select(prodPrice => prodPrice.Price)).SingleOrDefault();
            return productPrice;
        }

        #endregion

        public IEnumerable<ProductPricing> List()
        {
            List<ProductPricing> productPricings = (from productPricing in _dataContext.ProductPricings
                                                    orderby productPricing.Id descending
                                                    select productPricing).ToList();
            return productPricings;
        }

        public ProductPricing Get(int id)
        {
            ProductPricing productPricing =
                (from pricing in _dataContext.ProductPricings where pricing.Id == id select pricing).FirstOrDefault();
            return productPricing;
        }


        public void Add(int productId, ProductPricing productPricing)
        {
            var addr = new ProductPricing
                           {
                               ProductId = productId,
                               Price = productPricing.Price,
                               IsOnSale = productPricing.IsOnSale,
                               ModifiedDate = DateTime.Now
                           };

            _dataContext.ProductPricings.AddObject(addr);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, ProductPricing productPricing)
        {
            ProductPricing entityToEdit = (from cust in _dataContext.ProductPricings
                                           where cust.Id == id
                                           select cust).FirstOrDefault();

            entityToEdit.ProductId = productPricing.ProductId;
            entityToEdit.IsOnSale = productPricing.IsOnSale;
            entityToEdit.Price = productPricing.Price;
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public void Delete(int id, ProductPricing productPricing)
        {
            ProductPricing entityToEdit = (from cust in _dataContext.ProductPricings
                                           where cust.Id == id
                                           select cust).FirstOrDefault();

            _dataContext.DeleteObject(entityToEdit);
            _dataContext.SaveChanges();
        }
    }
}