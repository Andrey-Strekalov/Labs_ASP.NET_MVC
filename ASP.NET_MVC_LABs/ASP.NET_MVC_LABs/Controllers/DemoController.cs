using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC_LABs.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Hello()
        {

            return Content("Hello from DemoController!");
        }

        public IActionResult Greeting(String name)
        {
            return Content($"Hello, {name ?? "guest"}!");
        }

        public IActionResult ShowView()
        {
            ViewBag.UserName = "Андрей";
            ViewBag.RegistrationDate = new DateTime(2026, 10, 01);

            ViewData["PageTitle"] = "Информационная страница";
            ViewData["VisitCount"] = 42;

            return View();
        }

        public IActionResult UserInfo(string name, int age)
        {
            ViewBag.Name = name ?? "Неизвестный";
            ViewBag.Age = age;
            ViewBag.IsAdult = age >= 18;
            ViewData["CurrentYear"] = DateTime.Now.Year;
            ViewData["BirthYear"] = DateTime.Now.Year - age;
            ViewData["PageTitle"] = "Информация о пользователе";


            return View();
        }
    }
}
