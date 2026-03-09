using System.Collections.Generic;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories


{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetByCategory(string category);
        IEnumerable<Product> GetInStock(string category);

    }
}
