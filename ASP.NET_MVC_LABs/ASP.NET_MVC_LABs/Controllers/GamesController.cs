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
            return View(games); // ПЕРЕДАЕМ МОДЕЛЬ В ПРЕДСТАВЛЕНИЕ
        }

        // GET: /Games/Details/5
        public IActionResult Details(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // GET: /Games/Create
        public IActionResult Create()
        {
            // Передаем пустую модель для заполнения формы
            return View(new Game());
        }

        // POST: /Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid) // Исправлено: проверяем валидность, а не !IsValid
            {
                game.CreatedDate = DateTime.Now;
                _repository.Add(game);
                TempData["SucsessMessage"] = "Позиция успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            // Если модель невалидна, возвращаем представление с той же моделью для отображения ошибок
            return View(game);
        }

        // GET: /Games/Edit/5
        public IActionResult Edit(int id)
        {
            var game = _repository.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
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
                    TempData["SucsessMessage"] = "Позиция успешно обновлена"; // Исправлено сообщение
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            // Если модель невалидна или ошибка репозитория, возвращаем представление с моделью
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
            TempData["SucsessMessage"] = "Товар удален!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Games/Genre?genre=action
        public IActionResult Genre(string genre)
        {
            var games = _repository.GetByGenre(genre);
            ViewBag.Genre = genre;
            return View(games); // ПЕРЕДАЕМ МОДЕЛЬ В ПРЕДСТАВЛЕНИЕ
        }
    }
}