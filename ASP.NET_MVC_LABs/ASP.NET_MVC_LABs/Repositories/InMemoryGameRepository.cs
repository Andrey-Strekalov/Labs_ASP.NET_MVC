using System.Collections.Generic;
using ASP.NET_MVC_LABs.Models;
using System.Linq;

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

    public IEnumerable<Game> GetAll() => _games;

    void SeedData()
    {
        Add(new Game
        {
            Title = "Game1",
            Genre = "Genre1",
            Platform = "PS",
            Developer = "DEVGAME",
            ReleaseYear = 2010,
            CreatedDate = DateTime.Now,
            Rating = 7,
            IsMultiplayer = false,
        });
        Add(new Game
        {
            Title = "Game2",
            Genre = "Genre2",
            Platform = "XBOX",
            Developer = "DEVGAME",
            ReleaseYear = 2009,
            CreatedDate = DateTime.Now,
            Rating = 7,
            IsMultiplayer = true,
        });
        Add(new Game
        {
            Title = "Game3",
            Genre = "Genre3",
            Platform = "PS",
            Developer = "RusGame",
            ReleaseYear = 2000,
            CreatedDate = DateTime.Now,
            Rating = 9,
            IsMultiplayer = false,
        });
    }

    public void Add(Game game)
    {
        game.Id = ++_nextId;
        _games.Add(game);
    }

    public Game? GetById(int id) => _games.FirstOrDefault(p => p.Id == id);

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

    public void Delete(int id)
    {
        var game = GetById(id);
        if (game != null)
        {
            _games.Remove(game);
        }

    }

    public IEnumerable<Game> GetByGenre(string genre)
    {
        return _games.Where(p => p.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
    }

}

