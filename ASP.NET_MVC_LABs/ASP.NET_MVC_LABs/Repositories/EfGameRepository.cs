using Microsoft.EntityFrameworkCore;
using ASP.NET_MVC_LABs.Data;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories
{
    public class EfGameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public EfGameRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games.Find(id);
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = GetById(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Game> GetByGenre(string genre)
        {
            return _context.Games
                .Where(g => g.Genre == genre)
                .ToList();
        }
    }
}