using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products;
    private int _nextId = 1;

    public InMemoryProductRepository()
    {
        _products = new List<Product>();
        SeedData();
    }

    private void SeedData()
    {
        Add(new Product { Name = "Ноутбук ASUS", Price = 75000, Category = "Электроника", Description = "Игровой ноутбук", CreatedDate = DateTime.Now, InStock = true });
        Add(new Product { Name = "Смартфон Samsung", Price = 45000, Category = "Электроника", Description = "Galaxy S23", CreatedDate = DateTime.Now, InStock = true });
    }

    public IEnumerable<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product) { product.Id = ++_nextId; _products.Add(product); }

    public void Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Category = product.Category;
            existing.Description = product.Description;
            existing.InStock = product.InStock;
        }
    }

    public void Delete(int id) { var p = GetById(id); if (p != null) _products.Remove(p); }
    public IEnumerable<Product> GetByCategory(string category) => _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<Product> GetInStock(string category) => _products.Where(p => p.InStock);

    // Новые LINQ-методы
    public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice) =>
        _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).OrderBy(p => p.Price);

    public IEnumerable<Product> GetTopExpensiveProducts(int count) =>
        _products.OrderByDescending(p => p.Price).Take(count);

    public IEnumerable<Product> SearchProducts(string searchTerm) =>
        _products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                 .OrderBy(p => p.Name);

    public decimal GetAveragePrice() => _products.Average(p => p.Price);
    public int GetTotalCount() => _products.Count;

    public (decimal MinPrice, decimal MaxPrice) GetPriceRange() =>
        (MinPrice: _products.Min(p => p.Price), MaxPrice: _products.Max(p => p.Price));

    public bool AnyInCategory(string category) => _products.Any(p => p.Category == category);

    public IEnumerable<IGrouping<string, Product>> GetProductsGroupedByCategory() =>
        _products.GroupBy(p => p.Category).OrderBy(g => g.Key).ToList();

    public IEnumerable<Product> GetProductsWithPagination(int page, int pageSize) =>
        _products.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize);

    public int GetTotalPages(int pageSize) => (int)Math.Ceiling(GetTotalCount() / (double)pageSize);

    // Асинхронные методы (обёртки над синхронными)
    public Task<IEnumerable<Product>> GetAllAsync() => Task.FromResult(GetAll());
    public Task<Product?> GetByIdAsync(int id) => Task.FromResult(GetById(id));
    public Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice) => Task.FromResult(GetProductsByPriceRange(minPrice, maxPrice));
    public Task<decimal> GetAveragePriceAsync() => Task.FromResult(GetAveragePrice());
    public Task<int> GetTotalCountAsync() => Task.FromResult(GetTotalCount());
    public Task<IEnumerable<IGrouping<string, Product>>> GetProductsGroupedByCategoryAsync() => Task.FromResult(GetProductsGroupedByCategory());
}
