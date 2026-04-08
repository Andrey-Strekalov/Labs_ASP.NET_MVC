using ASP.NET_MVC_LABs.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP.NET_MVC_LABs.Data
{
    public class AppDbContext : DbContext
    {
        // Конструктор, принимающий параметры подключения
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        // DbSet представляет таблицу Products в базе данных
        public DbSet<Product> Products { get; set; }
        public DbSet<Game> Games { get; set; }

        // Дополнительная настройка модели (опционально)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Настройка для Product 
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.HasIndex(p => p.Category).HasDatabaseName("IX_Products_Category");
            });

            // НАСТРОЙКА ДЛЯ GAME 
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(g => g.Genre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(g => g.Platform)
                    .HasMaxLength(50);
                entity.Property(g => g.Developer)
                    .HasMaxLength(100);
                entity.Property(g => g.Rating)
                    .HasDefaultValue(0);
                entity.Property(g => g.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");
                // Индекс для быстрого поиска по жанру
                entity.HasIndex(g => g.Genre)
                    .HasDatabaseName("IX_Games_Genre");
            });

        }
    }
}
