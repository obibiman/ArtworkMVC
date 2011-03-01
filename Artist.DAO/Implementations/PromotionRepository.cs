using System;
using System.Collections.Generic;
using Artist.DAO.Interfaces;
using Artist.DAO.EntityFrameWork;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly KarenEntities _dataContext;

        public PromotionRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IPromotionRepository Members

        public decimal GetPromotionPricing(int productId, decimal currentPrice)
        {
            int denom = 100;
            DateTime currentDate = DateTime.Now;
            var salesPrice = (from sales in _dataContext.Promotions
                              where sales.ProductId == productId
                                    && (currentDate >= sales.SalesStartDate && currentDate <= sales.SalesEndDate)
                              select new {SalesPrice = currentPrice - currentPrice*sales.PercentDiscount/denom}).
                FirstOrDefault();

            return salesPrice.SalesPrice ?? currentPrice;
        }

        #endregion

        public IEnumerable<Promotion> List()
        {
            List<Promotion> promotions = (from promotion in _dataContext.Promotions
                                          orderby promotion.Id descending
                                          select promotion).ToList();
            return promotions;
        }

        public Promotion Get(int id)
        {
            Promotion promotion =
                (from promo in _dataContext.Promotions where promo.Id == id select promo).FirstOrDefault();
            return promotion;
        }


        public void Add(int productId, Promotion promotion)
        {
            var entity = new Promotion
                             {
                                 ProductId = productId,
                                 SalesEndDate = promotion.SalesEndDate,
                                 SalesStartDate = promotion.SalesStartDate,
                                 PercentDiscount = promotion.PercentDiscount,
                                 ModifiedDate = DateTime.Now
                             };

            _dataContext.Promotions.AddObject(entity);
            _dataContext.SaveChanges();
        }

        public void Edit(int id, Promotion promotion)
        {
            Promotion entityToEdit = (from cust in _dataContext.Promotions
                                      where cust.Id == id
                                      select cust).FirstOrDefault();

            entityToEdit.ProductId = promotion.ProductId;
            entityToEdit.SalesStartDate = promotion.SalesStartDate;
            entityToEdit.PercentDiscount = promotion.PercentDiscount;
            entityToEdit.SalesEndDate = promotion.SalesEndDate;
            entityToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public void Delete(int id, Promotion promotion)
        {
            Promotion entity = (from promo in _dataContext.Promotions
                                where promo.Id == id
                                select promo).FirstOrDefault();

            _dataContext.DeleteObject(entity);
            _dataContext.SaveChanges();
        }
    }
}