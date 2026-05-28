using System.Collections.Generic;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories
{
    public interface IGameRepository
    {
        // Существующие методы
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
        IEnumerable<Game> GetByGenre(string genre);

        // Фильтрация по году
        IEnumerable<Game> GetByYear(int year);
        // Топ N игр по рейтингу
        IEnumerable<Game> GetTopRatedGames(int count);
        // Поиск по тексту
        IEnumerable<Game> SearchGames(string searchTerm);
        // Статистика
        double GetAverageRating();
        int GetTotalCount();
        // Группировка по жанру
        IEnumerable<IGrouping<string, Game>> GetGamesGroupedByGenre();
        // Пагинация
        IEnumerable<Game> GetGamesWithPagination(int page, int pageSize);
        int GetTotalPages(int pageSize);
        // Асинхронные версии
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game?> GetByIdAsync(int id);
        Task<IEnumerable<Game>> GetByYearAsync(int year);
        Task<IEnumerable<Game>> GetTopRatedGamesAsync(int count);
        Task<double> GetAverageRatingAsync();
        Task<int> GetTotalCountAsync();
        Task<IEnumerable<IGrouping<string, Game>>> GetGamesGroupedByGenreAsync();
    }
}
