using System.Collections.Generic;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories
{
    public interface IProductRepository
    {
        // Существующие методы
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetByCategory(string category);
        IEnumerable<Product> GetInStock(string category);

        // Фильтрация по цене
        IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
        // Топ N самых дорогих товаров
        IEnumerable<Product> GetTopExpensiveProducts(int count);
        // Поиск по тексту
        IEnumerable<Product> SearchProducts(string searchTerm);
        // Статистика
        decimal GetAveragePrice();
        int GetTotalCount();
        (decimal MinPrice, decimal MaxPrice) GetPriceRange();
        bool AnyInCategory(string category);
        // Группировка
        IEnumerable<IGrouping<string, Product>> GetProductsGroupedByCategory();
        // Пагинация
        IEnumerable<Product> GetProductsWithPagination(int page, int pageSize);
        int GetTotalPages(int pageSize);
        // Асинхронные версии
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<decimal> GetAveragePriceAsync();
        Task<int> GetTotalCountAsync();
        Task<IEnumerable<IGrouping<string, Product>>> GetProductsGroupedByCategoryAsync();
    }
}
