using System;
using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class ProductPricingService : IProductPricingService
    {
        private readonly IProductPricingRepository _productPricingRepository;

        public ProductPricingService(IProductPricingRepository productPricingRepository)
        {
            _productPricingRepository = productPricingRepository;
        }

        public IEnumerable<ProductPricing> List()
        {
            return _productPricingRepository.List();
        }

        public void Add(int id, ProductPricing productPricing)
        {
            _productPricingRepository.Add(id, productPricing);
        }

        public ProductPricing Get(int id)
        {
            return _productPricingRepository.Get(id);
        }

        public void Edit(int id, ProductPricing productPricing)
        {
            _productPricingRepository.Edit(id, productPricing);
        }

        public void Delete(int Id, ProductPricing productPricing)
        {
            _productPricingRepository.Delete(Id, productPricing);
        }

        public decimal GetPricing(int productId)
        {
            return _productPricingRepository.GetPricing(productId);
        }
    }
}