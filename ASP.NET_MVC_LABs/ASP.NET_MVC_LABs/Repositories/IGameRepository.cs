using System.Collections.Generic;
using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        void Add(Game game);
        void Update(Game game);
        void Delete(int id);
        IEnumerable<Game> GetByGenre(string genre);

    }
}
