using System.Collections.Generic;
using Artist.DAO.Business.Interfaces;
using Artist.DAO.EntityFrameWork;
using Artist.DAO.Interfaces;

namespace Artist.DAO.Business.ValueAdded
{
    class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region IProductService Members

        public IEnumerable<Product> List()
        {
            return _productRepository.List();
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public void UploadOrUpdateProduct(string fileName, string mimeType, byte[] image, string description, decimal length, decimal width, string material)
        {
            _productRepository.UploadOrUpdateProduct(fileName, mimeType, image, description, length, width, material);
        }

        public void Edit(int id, Product product)
        {
            _productRepository.Edit(id, product);
        }

        public void Delete(int Id, Product product)
        {
           _productRepository.Delete(Id, product);
        }

        #endregion
    }
}