using ASP.NET_MVC_LABs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("library")]
public class Library : Controller
{
    private static readonly List<Book> _books = new List<Book>
    {
        new Book { Title = "Война и мир", Author = "Толстой", Year = 1869, ISBN = "978-5-17-123456-7" },
        new Book { Title = "Преступление и наказание", Author = "Достоевский", Year = 1866, ISBN = "978-5-17-123457-4" },
        new Book { Title = "Анна Каренина", Author = "Толстой", Year = 1877, ISBN = "978-5-17-123458-1" },
        new Book { Title = "Евгений Онегин", Author = "Пушкин", Year = 1833, ISBN = "978-5-17-123459-8" },
        new Book { Title = "Герой нашего времени", Author = "Лермонтов", Year = 1840, ISBN = "978-5-17-123460-4" },
        new Book { Title = "Мертвые души", Author = "Гоголь", Year = 1842, ISBN = "978-5-17-123461-1" },
        new Book { Title = "Отцы и дети", Author = "Тургенев", Year = 1862, ISBN = "978-5-17-123462-8" },
        new Book { Title = "Обломов", Author = "Гончаров", Year = 1859, ISBN = "978-5-17-123463-5" },
        new Book { Title = "Вишневый сад", Author = "Чехов", Year = 1904, ISBN = "978-5-17-123464-2" },
        new Book { Title = "На дне", Author = "Горький", Year = 1902, ISBN = "978-5-17-123465-9" },
        new Book { Title = "Тихий Дон", Author = "Шолохов", Year = 1928, ISBN = "978-5-17-123466-6" },
        new Book { Title = "Доктор Живаго", Author = "Пастернак", Year = 1957, ISBN = "978-5-17-123467-3" },
        new Book { Title = "Мастер и Маргарита", Author = "Булгаков", Year = 1967, ISBN = "978-5-17-123468-0" },
        new Book { Title = "Собачье сердце", Author = "Булгаков", Year = 1925, ISBN = "978-5-17-123469-7" },
        new Book { Title = "1984", Author = "Оруэлл", Year = 1949, ISBN = "978-5-17-123470-3" },
        new Book { Title = "Улисс", Author = "Джойс", Year = 1922, ISBN = "978-5-17-123471-0" },
        new Book { Title = "Сто лет одиночества", Author = "Маркес", Year = 1967, ISBN = "978-5-17-123472-7" },
        new Book { Title = "Великий Гэтсби", Author = "Фицджеральд", Year = 1925, ISBN = "978-5-17-123473-4" },
        new Book { Title = "Над пропастью во ржи", Author = "Сэлинджер", Year = 1951, ISBN = "978-5-17-123474-1" },
        new Book { Title = "Портрет Дориана Грея", Author = "Уайльд", Year = 1890, ISBN = "978-5-17-123475-8" }
    };

    [Route("home")]
    public IActionResult Index()
    {
        ViewBag.LibraryName = "Государственная библиотека им. Ленина";
        ViewBag.AboutLibraryText = "История главной библиотеки страны началась в 1862 году, когда император Александр II утвердил положение о создании Московского публичного музеума и Румянцевского музеума . Тогда она размещалась в Доме Пашкова, а её основой стала коллекция графа Румянцева . В 1925 году учреждение получило название Государственная библиотека СССР имени В. И. Ленина, и за ней навсегда закрепилось народное имя «Ленинка» . Из-за стремительного роста книжного фонда возникла необходимость в новом здании . В 1928–1941 годах на Воздвиженке по проекту архитекторов Щуко и Гельфрейха был возведён монументальный комплекс в стиле сталинский ампир . Рядом с библиотекой открылась станция метро, названная в её честь . Здание украшают скульптурный фриз и медальоны с портретами великих учёных и писателей . Сегодня Российская государственная библиотека — одна из крупнейших в мире: её фонды насчитывают более 47 миллионов единиц хранения . В 36 читальных залах могут одновременно работать тысячи посетителей, а для транспортировки книг здесь ещё в 1947 году был установлен специальный конвейер . С 1992 года библиотека носит своё современное имя, однако историческое название по-прежнему можно увидеть на её фасаде . \"Ленинка\" была и остаётся не просто книгохранилищем, а настоящим символом знаний и культуры, знакомым каждому жителю России .";

        return View();
    }

    [Route("catalog")]
    public IActionResult Catalog()
    {
        ViewBag.BookList = _books;
        return View();
    }

    [Route("book/{isbn}")]
    public IActionResult Book(string isbn)
    {
        var book = _books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
            return NotFound();

        // Передаём книгу через ViewBag (или можно использовать модель)
        ViewBag.Book = book;
        return View();
    }

    [Route("search")]
    public IActionResult Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            // Если запрос пустой, можно показать пустой результат или перенаправить
            ViewBag.SearchQuery = query;
            ViewBag.SearchResults = new List<Book>();
            return View();
        }

        // Выполняем поиск по названию, автору или году (приводим год к строке)
        var results = _books.Where(b =>
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Year.ToString().Contains(query)
        ).ToList();

        ViewBag.SearchQuery = query;
        ViewBag.SearchResults = results;
        ViewBag.ResultsCount = results.Count;

        return View();
    }
}
