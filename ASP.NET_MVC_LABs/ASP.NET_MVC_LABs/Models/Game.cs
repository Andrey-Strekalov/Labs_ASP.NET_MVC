using System.ComponentModel.DataAnnotations;

namespace ASP.NET_MVC_LABs.Models
{
    public class Game
    {
        public Game()
        {
            Title = string.Empty;
            Genre = string.Empty;
            Platform = string.Empty;
            Developer = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Введите заголовок")]
        [Display(Name="Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите жанр игры")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Платформа")]
        public string Platform { get; set; }

        [Display(Name = "Год релиза")]
        [Range(1970, 2027, ErrorMessage ="Год релиза от 1970 до 2027")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Разработчик")]
        public string Developer { get; set; }

        [Range(0, 10, ErrorMessage = "Рейтниг от 0 до 10")]
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }

        [Display(Name = "Мультиплеер")]
        public bool IsMultiplayer { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public int GetAge(int year)
        {
            return DateTime.Now.Year - year;
        }
    }
}
