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

        // ========== СУЩЕСТВУЮЩИЕ МЕТОДЫ ==========

        public IEnumerable<Game> GetAll() => _context.Games.ToList();

        public Game? GetById(int id) => _context.Games.Find(id);

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

        public IEnumerable<Game> GetByGenre(string genre) =>
            _context.Games.Where(g => g.Genre == genre).ToList();

        // ========== НОВЫЕ LINQ-МЕТОДЫ ==========

        public IEnumerable<Game> GetByYear(int year) =>
            _context.Games
                .Where(g => g.ReleaseYear == year)
                .OrderBy(g => g.Title)
                .ToList();

        public IEnumerable<Game> GetTopRatedGames(int count) =>
            _context.Games
                .OrderByDescending(g => g.Rating)
                .Take(count)
                .ToList();

        public IEnumerable<Game> SearchGames(string searchTerm) =>
            _context.Games
                .Where(g => g.Title.Contains(searchTerm) ||
                            g.Genre.Contains(searchTerm) ||
                            g.Developer.Contains(searchTerm) ||
                            g.Platform.Contains(searchTerm))
                .OrderBy(g => g.Title)
                .ToList();

        public double GetAverageRating() =>
            _context.Games.Average(g => (double)g.Rating);

        public int GetTotalCount() =>
            _context.Games.Count();

        public IEnumerable<IGrouping<string, Game>> GetGamesGroupedByGenre() =>
            _context.Games
                .GroupBy(g => g.Genre)
                .OrderBy(g => g.Key)
                .ToList();

        public IEnumerable<Game> GetGamesWithPagination(int page, int pageSize) =>
            _context.Games
                .OrderBy(g => g.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public int GetTotalPages(int pageSize)
        {
            var totalCount = GetTotalCount();
            return (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        // ========== АСИНХРОННЫЕ МЕТОДЫ ==========

        public async Task<IEnumerable<Game>> GetAllAsync() =>
            await _context.Games.ToListAsync();

        public async Task<Game?> GetByIdAsync(int id) =>
            await _context.Games.FindAsync(id);

        public async Task<IEnumerable<Game>> GetByYearAsync(int year) =>
            await _context.Games
                .Where(g => g.ReleaseYear == year)
                .OrderBy(g => g.Title)
                .ToListAsync();

        public async Task<IEnumerable<Game>> GetTopRatedGamesAsync(int count) =>
            await _context.Games
                .OrderByDescending(g => g.Rating)
                .Take(count)
                .ToListAsync();

        public async Task<double> GetAverageRatingAsync() =>
            await _context.Games.AverageAsync(g => (double)g.Rating);

        public async Task<int> GetTotalCountAsync() =>
            await _context.Games.CountAsync();

        public async Task<IEnumerable<IGrouping<string, Game>>> GetGamesGroupedByGenreAsync() =>
            await _context.Games
                .GroupBy(g => g.Genre)
                .OrderBy(g => g.Key)
                .ToListAsync();
    }
}
