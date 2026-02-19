namespace ASP.NET_MVC_LABs.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; } // уникальный идентификатор
    }
}