using Microsoft.AspNetCore.Mvc;
using ASP.NET_MVC_LABs.Models;
using ASP.NET_MVC_LABs.Repositories;

namespace ASP.NET_MVC_LABs.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _repository;

        public GamesController(IGameRepository repository)
        {
            _repository = repository;
        }

        // GET: /Games
        public IActionResult Index()
        {
            var games = _repository.GetAll();
            return View(games);
        }

        // GET: /Games/Details/5
        public IActionResult Details(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
                return NotFound();
            return View(game);
        }

        // GET: /Games/Create
        public IActionResult Create()
        {
            return View(new Game());
        }

        // POST: /Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                game.CreatedDate = DateTime.Now;
                _repository.Add(game);
                TempData["SucsessMessage"] = "Позиция успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: /Games/Edit/5
        public IActionResult Edit(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
                return NotFound();
            return View(game);
        }

        // POST: /Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Game game)
        {
            if (id != game.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(game);
                    TempData["SucsessMessage"] = "Позиция успешно обновлена";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(game);
        }

        // GET: /Games/Delete/5
        public IActionResult Delete(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
                return NotFound();
            return View(game);
        }

        // POST: /Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["SucsessMessage"] = "Игра удалена!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Games/Genre?genre=action
        public IActionResult Genre(string genre)
        {
            var games = _repository.GetByGenre(genre);
            ViewBag.Genre = genre;
            return View(games);
        }

        // GET: /Games/ByYear?year=2020
        public IActionResult ByYear(int year)
        {
            var games = _repository.GetByYear(year);
            ViewBag.Year = year;
            ViewBag.Title = $"Игры {year} года";
            return View(games);
        }

        // GET: /Games/TopRated?count=5
        public IActionResult TopRated(int count = 5)
        {
            var games = _repository.GetTopRatedGames(count);
            ViewBag.Title = $"Топ {count} игр по рейтингу";
            ViewBag.Count = count;
            return View(games);
        }

        // GET: /Games/Search?term=witcher
        public IActionResult Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                ViewBag.SearchTerm = string.Empty;
                ViewBag.Title = "Поиск игр";
                return View(Enumerable.Empty<Game>());
            }

            var games = _repository.SearchGames(term);
            ViewBag.SearchTerm = term;
            ViewBag.Title = $"Результаты поиска: {term}";
            ViewBag.Count = games.Count();
            return View(games);
        }

        // GET: /Games/Statistics
        public IActionResult Statistics()
        {
            var games = _repository.GetAll();
            var stats = new GamesStatisticsViewModel
            {
                TotalCount = _repository.GetTotalCount(),
                AverageRating = _repository.GetAverageRating(),
                MultiplayerCount = games.Count(g => g.IsMultiplayer),
                Genres = games
                    .GroupBy(g => g.Genre)
                    .Select(g => new GenreStatViewModel
                    {
                        Genre = g.Key ?? "Без жанра",
                        Count = g.Count(),
                        AverageRating = g.Average(x => (double)x.Rating),
                        MaxRating = g.Max(x => x.Rating),
                        MinRating = g.Min(x => x.Rating)
                    })
                    .OrderBy(g => g.Genre)
            };
            return View(stats);
        }

        // GET: /Games/GroupedByGenre
        public IActionResult GroupedByGenre()
        {
            var games = _repository.GetAll();
            return View(games);
        }

        // GET: /Games/Paginated?page=1
        public IActionResult Paginated(int page = 1, int pageSize = 5)
        {
            var games = _repository.GetGamesWithPagination(page, pageSize);
            var totalPages = _repository.GetTotalPages(pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = page > 1;
            ViewBag.HasNextPage = page < totalPages;
            return View(games);
        }
    }
}
