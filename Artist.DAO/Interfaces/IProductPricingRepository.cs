using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IProductPricingRepository
    {
        IEnumerable<ProductPricing> List();
        void Add(int id, ProductPricing productPricing);
        ProductPricing Get(int id);
        void Edit(int id, ProductPricing productPricing);
        void Delete(int Id, ProductPricing productPricing);
        decimal GetPricing(int productId);
    }
}