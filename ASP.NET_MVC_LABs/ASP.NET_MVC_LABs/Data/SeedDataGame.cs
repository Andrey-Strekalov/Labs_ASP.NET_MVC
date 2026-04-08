using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Data
{
    public static class SeedDataGames
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            // Если уже есть игры – выходим
            if (context.Games.Any())
                return;

            var games = new Game[]
            {
                new Game
                {
                    Title = "The Witcher 3: Wild Hunt",
                    Genre = "RPG",
                    Platform = "PC, PS4, Xbox One",
                    Developer = "CD Projekt Red",
                    ReleaseYear = 2015,
                    Rating = 10,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-120)
                },
                new Game
                {
                    Title = "Counter-Strike 2",
                    Genre = "Shooter",
                    Platform = "PC",
                    Developer = "Valve",
                    ReleaseYear = 2023,
                    Rating = 9,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-30)
                },
                new Game
                {
                    Title = "Hollow Knight",
                    Genre = "Metroidvania",
                    Platform = "PC, Switch, PS4",
                    Developer = "Team Cherry",
                    ReleaseYear = 2017,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-200)
                },
                new Game
                {
                    Title = "Elden Ring",
                    Genre = "RPG",
                    Platform = "PC, PS5, Xbox Series",
                    Developer = "FromSoftware",
                    ReleaseYear = 2022,
                    Rating = 10,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-90)
                }
            };

            await context.Games.AddRangeAsync(games);
            await context.SaveChangesAsync();
        }
    }
}