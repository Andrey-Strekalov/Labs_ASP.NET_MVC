using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC_LABs.Controllers
{
    [Route("store")]
    [Route("shop")]


    public class ShopController : Controller
    {

        // GET: /store
        // GET: /shop
        public IActionResult Index()
        {
            ViewBag.StoreName = "Магазин 'У Михалыча'";
            ViewData["ProductsCount"] = 15;
            return View();
        }


        // GET: /store/category/electronics
        // GET: /shop/category/electronics
        [Route("category/{categoryName}")]

        public IActionResult Category(string categoryName)
        {
            ViewBag.Category = categoryName;
            ViewBag.Products = new[] { "Ноутбук", "Смартфон", "Планшет" };
            return View();
        }

        // GET: /store/product/42/details
        [Route("product/{id}/details")]
        public IActionResult ProductDetails(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.ProductName = $"Товар #{id}";
            ViewBag.Rating = (id % 5) + 1;
            return View();
        }

        // GET: /store/product/42-1/details
        [Route("product/{id}/prev/details")]
        public IActionResult PrevProductDetails(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.ProductName = $"Товар #{id}";
            ViewBag.Rating = (id % 5) + 1;
            return View("ProductDetails");
        }

        // GET: /store/product/42+1/details
        [Route("product/{id}/next/details")]
        public IActionResult NextProductDetails(int id)
        {
            ViewBag.ProductId = id;
            ViewBag.ProductName = $"Товар #{id}";
            ViewBag.Rating = (id % 5) + 1;
            return View("ProductDetails");
        }


    }
}
