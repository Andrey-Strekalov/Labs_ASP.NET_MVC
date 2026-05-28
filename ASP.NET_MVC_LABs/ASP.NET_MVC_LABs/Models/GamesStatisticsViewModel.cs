namespace ASP.NET_MVC_LABs.Models
{
    public class GamesStatisticsViewModel
    {
        public int TotalCount { get; set; }
        public double AverageRating { get; set; }
        public int MultiplayerCount { get; set; }
        public IEnumerable<GenreStatViewModel> Genres { get; set; } = new List<GenreStatViewModel>();
    }

    public class GenreStatViewModel
    {
        public string Genre { get; set; } = string.Empty;
        public int Count { get; set; }
        public double AverageRating { get; set; }
        public int MaxRating { get; set; }
        public int MinRating { get; set; }
    }
}
