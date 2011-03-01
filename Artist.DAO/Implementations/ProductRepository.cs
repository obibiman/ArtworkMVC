using System;
using System.Collections.Generic;
using System.Linq;
using Artist.DAO.Interfaces;
using Artist.DAO.EntityFrameWork;
using System.Linq;

namespace Artist.DAO.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly KarenEntities _dataContext;

        public ProductRepository()
        {
            _dataContext = new KarenEntities();
        }

        #region IProductRepository Members

        public void UploadOrUpdateProduct(string fileName, string mimeType, byte[] image, string description,
                                          decimal length, decimal width, string material)
        {
            Product product = (_dataContext.Products.Where(imageStore => imageStore.Image == image)).FirstOrDefault();

            if (product == null)
            {
                var prod = new Product
                               {
                                   Id = PrimaryKeyUtil.RandomNumber(1, 100903),
                                   Name = fileName,
                                   MimeType = mimeType,
                                   Image = image,
                                   Description = description,
                                   Length = length,
                                   Width = width,
                                   Material = material,
                                   ModifiedDate = DateTime.Now
                               };
                _dataContext.Products.AddObject(prod);
            }
            else
            {
                product.Image = image;
                product.MimeType = mimeType;
                product.Name = fileName;
                product.Description = description;
                product.Length = length;
                product.Width = width;
                product.Material = material;
                product.ModifiedDate = DateTime.Now;
            }
            _dataContext.SaveChanges();
        }

        #endregion

        public IEnumerable<Product> List()
        {
            IQueryable<Product> products =
                (from painting in _dataContext.Products
                 select painting);

            return products;
        }

        public Product Get(int id)
        {
            Product product = (_dataContext.Products.Where(cust => cust.Id == id)).FirstOrDefault();
            return product;
        }

        public void Edit(int id, Product product)
        {
            Product paintingToEdit = (from cust in _dataContext.Products
                                      where cust.Id == id
                                      select cust).FirstOrDefault();

            paintingToEdit.Image = product.Image;
            paintingToEdit.Name = product.Name;
            paintingToEdit.MimeType = product.MimeType;
            paintingToEdit.Description = product.Description;
            paintingToEdit.Length = product.Length;
            paintingToEdit.Width = product.Width;
            paintingToEdit.Material = product.Material;
            paintingToEdit.ModifiedDate = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public void Delete(int Id, Product prod)
        {
            Product product = (from cust in _dataContext.Products
                               where cust.Id == Id
                               select cust).FirstOrDefault();

            _dataContext.DeleteObject(product);
            _dataContext.SaveChanges();
        }
    }
}