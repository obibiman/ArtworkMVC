using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;

namespace Artist.DAO.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> List();
        Product Get(int id);

        void UploadOrUpdateProduct(string fileName, string mimeType, byte[] image, string description, decimal length,
                                   decimal width, string material);

        //new/new
        void Edit(int id, Product product);
        void Delete(int Id, Product product);
    }
}