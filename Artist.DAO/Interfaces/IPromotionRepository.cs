using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IPromotionRepository
    {
        IEnumerable<Promotion> List();
        void Add(int id, Promotion promotion);
        Promotion Get(int id);
        void Edit(int id, Promotion promotion);
        void Delete(int Id, Promotion promotion);
        decimal GetPromotionPricing(int productId, decimal currentPrice);
    }
}