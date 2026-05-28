using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Data
{
    public static class SeedDataGames
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Games.Any())
                return;

            var games = new Game[]
            {
                new Game
                {
                    Title = "The Witcher 3: Wild Hunt",
                    Genre = "RPG",
                    Platform = "PC, PS4, Xbox One, Switch",
                    Developer = "CD Projekt Red",
                    ReleaseYear = 2015,
                    Rating = 10,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-120)
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
                },
                new Game
                {
                    Title = "Red Dead Redemption 2",
                    Genre = "Action-Adventure",
                    Platform = "PC, PS4, Xbox One",
                    Developer = "Rockstar Games",
                    ReleaseYear = 2018,
                    Rating = 10,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-200)
                },
                new Game
                {
                    Title = "Counter-Strike 2",
                    Genre = "Shooter",
                    Platform = "PC",
                    Developer = "Valve",
                    ReleaseYear = 2023,
                    Rating = 8,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-30)
                },
                new Game
                {
                    Title = "Hollow Knight",
                    Genre = "Metroidvania",
                    Platform = "PC, Switch, PS4, Xbox One",
                    Developer = "Team Cherry",
                    ReleaseYear = 2017,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-150)
                },
                new Game
                {
                    Title = "Cyberpunk 2077",
                    Genre = "RPG",
                    Platform = "PC, PS5, Xbox Series",
                    Developer = "CD Projekt Red",
                    ReleaseYear = 2020,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-80)
                },
                new Game
                {
                    Title = "Hades",
                    Genre = "Roguelike",
                    Platform = "PC, Switch, PS4, Xbox One",
                    Developer = "Supergiant Games",
                    ReleaseYear = 2020,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-110)
                },
                new Game
                {
                    Title = "God of War",
                    Genre = "Action-Adventure",
                    Platform = "PC, PS4, PS5",
                    Developer = "Santa Monica Studio",
                    ReleaseYear = 2018,
                    Rating = 10,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-95)
                },
                new Game
                {
                    Title = "Dota 2",
                    Genre = "MOBA",
                    Platform = "PC",
                    Developer = "Valve",
                    ReleaseYear = 2013,
                    Rating = 8,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-300)
                },
                new Game
                {
                    Title = "Minecraft",
                    Genre = "Sandbox",
                    Platform = "PC, PS4, Xbox One, Switch, Mobile",
                    Developer = "Mojang",
                    ReleaseYear = 2011,
                    Rating = 9,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-400)
                },
                new Game
                {
                    Title = "Dark Souls III",
                    Genre = "RPG",
                    Platform = "PC, PS4, Xbox One",
                    Developer = "FromSoftware",
                    ReleaseYear = 2016,
                    Rating = 9,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-180)
                },
                new Game
                {
                    Title = "Stardew Valley",
                    Genre = "Simulation",
                    Platform = "PC, Switch, PS4, Xbox One, Mobile",
                    Developer = "ConcernedApe",
                    ReleaseYear = 2016,
                    Rating = 9,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-250)
                },
                new Game
                {
                    Title = "Portal 2",
                    Genre = "Puzzle",
                    Platform = "PC, PS3, Xbox 360",
                    Developer = "Valve",
                    ReleaseYear = 2011,
                    Rating = 10,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-500)
                },
                new Game
                {
                    Title = "FIFA 24",
                    Genre = "Sports",
                    Platform = "PC, PS5, Xbox Series, Switch",
                    Developer = "EA Sports",
                    ReleaseYear = 2023,
                    Rating = 7,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-40)
                },
                new Game
                {
                    Title = "Civilization VI",
                    Genre = "Strategy",
                    Platform = "PC, PS4, Xbox One, Switch",
                    Developer = "Firaxis Games",
                    ReleaseYear = 2016,
                    Rating = 8,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-220)
                },
                new Game
                {
                    Title = "Sekiro: Shadows Die Twice",
                    Genre = "Action-Adventure",
                    Platform = "PC, PS4, Xbox One",
                    Developer = "FromSoftware",
                    ReleaseYear = 2019,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-160)
                },
                new Game
                {
                    Title = "Terraria",
                    Genre = "Sandbox",
                    Platform = "PC, PS4, Xbox One, Switch, Mobile",
                    Developer = "Re-Logic",
                    ReleaseYear = 2011,
                    Rating = 9,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-350)
                },
                new Game
                {
                    Title = "Disco Elysium",
                    Genre = "RPG",
                    Platform = "PC, PS4, PS5",
                    Developer = "ZA/UM",
                    ReleaseYear = 2019,
                    Rating = 9,
                    IsMultiplayer = false,
                    CreatedDate = DateTime.Now.AddDays(-130)
                },
                new Game
                {
                    Title = "Call of Duty: Modern Warfare II",
                    Genre = "Shooter",
                    Platform = "PC, PS5, Xbox Series",
                    Developer = "Infinity Ward",
                    ReleaseYear = 2022,
                    Rating = 7,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-70)
                },
                new Game
                {
                    Title = "Baldur's Gate 3",
                    Genre = "RPG",
                    Platform = "PC, PS5, Xbox Series",
                    Developer = "Larian Studios",
                    ReleaseYear = 2023,
                    Rating = 10,
                    IsMultiplayer = true,
                    CreatedDate = DateTime.Now.AddDays(-20)
                }
            };

            await context.Games.AddRangeAsync(games);
            await context.SaveChangesAsync();
        }
    }
}
