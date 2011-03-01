using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        #region IPromotionService Members

        public IEnumerable<Promotion> List()
        {
            return _promotionRepository.List();
        }

        public void Add(int id, Promotion promotion)
        {
           _promotionRepository.Add(id, promotion);
        }

        public Promotion Get(int id)
        {
            return _promotionRepository.Get(id);
        }

        public void Edit(int id, Promotion promotion)
        {
            _promotionRepository.Edit(id, promotion);
        }

        public void Delete(int Id, Promotion promotion)
        {
            _promotionRepository.Delete(Id, promotion);
        }

        public decimal GetPromotionPricing(int productId, decimal currentPrice)
        {
            return _promotionRepository.GetPromotionPricing(productId, currentPrice);
        }

        #endregion
    }
}