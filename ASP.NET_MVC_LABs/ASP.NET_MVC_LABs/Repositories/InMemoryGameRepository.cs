using System.Collections.Generic;
using System.Linq;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories;

public class InMemoryGameRepository : IGameRepository
{
    private readonly List<Game> _games;
    private int _nextId = 1;

    public InMemoryGameRepository()
    {
        _games = new List<Game>();
        SeedData();
    }

    void SeedData()
    {
        Add(new Game { Title = "Game1", Genre = "Genre1", Platform = "PS", Developer = "DEVGAME", ReleaseYear = 2010, CreatedDate = DateTime.Now, Rating = 7, IsMultiplayer = false });
        Add(new Game { Title = "Game2", Genre = "Genre2", Platform = "XBOX", Developer = "DEVGAME", ReleaseYear = 2009, CreatedDate = DateTime.Now, Rating = 7, IsMultiplayer = true });
        Add(new Game { Title = "Game3", Genre = "Genre3", Platform = "PS", Developer = "RusGame", ReleaseYear = 2000, CreatedDate = DateTime.Now, Rating = 9, IsMultiplayer = false });
    }

    public IEnumerable<Game> GetAll() => _games;
    public Game? GetById(int id) => _games.FirstOrDefault(g => g.Id == id);

    public void Add(Game game) { game.Id = ++_nextId; _games.Add(game); }

    public void Update(Game game)
    {
        var existing = GetById(game.Id);
        if (existing != null)
        {
            existing.Title = game.Title;
            existing.Genre = game.Genre;
            existing.Platform = game.Platform;
            existing.ReleaseYear = game.ReleaseYear;
            existing.Developer = game.Developer;
            existing.Rating = game.Rating;
            existing.IsMultiplayer = game.IsMultiplayer;
        }
    }

    public void Delete(int id) { var g = GetById(id); if (g != null) _games.Remove(g); }
    public IEnumerable<Game> GetByGenre(string genre) => _games.Where(g => g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

    // Новые LINQ-методы
    public IEnumerable<Game> GetByYear(int year) =>
        _games.Where(g => g.ReleaseYear == year).OrderBy(g => g.Title);

    public IEnumerable<Game> GetTopRatedGames(int count) =>
        _games.OrderByDescending(g => g.Rating).Take(count);

    public IEnumerable<Game> SearchGames(string searchTerm) =>
        _games.Where(g => g.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                          g.Genre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                          g.Developer.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                          g.Platform.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
              .OrderBy(g => g.Title);

    public double GetAverageRating() => _games.Average(g => (double)g.Rating);
    public int GetTotalCount() => _games.Count;

    public IEnumerable<IGrouping<string, Game>> GetGamesGroupedByGenre() =>
        _games.GroupBy(g => g.Genre).OrderBy(g => g.Key).ToList();

    public IEnumerable<Game> GetGamesWithPagination(int page, int pageSize) =>
        _games.OrderBy(g => g.Id).Skip((page - 1) * pageSize).Take(pageSize);

    public int GetTotalPages(int pageSize) => (int)Math.Ceiling(GetTotalCount() / (double)pageSize);

    // Асинхронные методы (обёртки над синхронными)
    public Task<IEnumerable<Game>> GetAllAsync() => Task.FromResult(GetAll());
    public Task<Game?> GetByIdAsync(int id) => Task.FromResult(GetById(id));
    public Task<IEnumerable<Game>> GetByYearAsync(int year) => Task.FromResult(GetByYear(year));
    public Task<IEnumerable<Game>> GetTopRatedGamesAsync(int count) => Task.FromResult(GetTopRatedGames(count));
    public Task<double> GetAverageRatingAsync() => Task.FromResult(GetAverageRating());
    public Task<int> GetTotalCountAsync() => Task.FromResult(GetTotalCount());
    public Task<IEnumerable<IGrouping<string, Game>>> GetGamesGroupedByGenreAsync() => Task.FromResult(GetGamesGroupedByGenre());
}
