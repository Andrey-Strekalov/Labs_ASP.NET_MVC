using ASP.NET_MVC_LABs.Models;

namespace ASP.NET_MVC_LABs.Data
{
    public static class SeedDataProduct
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Products.Any())
                return;

            var products = new Product[]
            {
                new Product
                {
                    Name = "Ноутбук ASUS ROG Strix",
                    Price = 120000,
                    Category = "Электроника",
                    Description = "Игровой ноутбук с RTX 4070, 16GB RAM, 1TB SSD",
                    CreatedDate = DateTime.Now.AddDays(-90),
                    InStock = true
                },
                new Product
                {
                    Name = "Смартфон Samsung Galaxy S24",
                    Price = 75000,
                    Category = "Электроника",
                    Description = "Флагманский смартфон с AI-функциями, 256GB",
                    CreatedDate = DateTime.Now.AddDays(-45),
                    InStock = true
                },
                new Product
                {
                    Name = "Телевизор LG OLED 55\"",
                    Price = 95000,
                    Category = "Электроника",
                    Description = "OLED-панель 4K 120Гц, Smart TV, Dolby Vision",
                    CreatedDate = DateTime.Now.AddDays(-60),
                    InStock = true
                },
                new Product
                {
                    Name = "Наушники Sony WH-1000XM5",
                    Price = 28000,
                    Category = "Электроника",
                    Description = "Беспроводные наушники с ANC, 30ч батарея",
                    CreatedDate = DateTime.Now.AddDays(-20),
                    InStock = true
                },
                new Product
                {
                    Name = "Планшет iPad Pro 12.9\"",
                    Price = 110000,
                    Category = "Электроника",
                    Description = "Apple M2, 256GB, экран Liquid Retina XDR",
                    CreatedDate = DateTime.Now.AddDays(-30),
                    InStock = false
                },
                new Product
                {
                    Name = "Клавиатура Keychron K2 Pro",
                    Price = 9500,
                    Category = "Электроника",
                    Description = "Механическая беспроводная, переключатели Brown",
                    CreatedDate = DateTime.Now.AddDays(-15),
                    InStock = true
                },
                new Product
                {
                    Name = "Книга «Чистый код»",
                    Price = 1800,
                    Category = "Книги",
                    Description = "Роберт Мартин. Создание, анализ и рефакторинг",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    InStock = true
                },
                new Product
                {
                    Name = "Книга «Паттерны проектирования»",
                    Price = 2100,
                    Category = "Книги",
                    Description = "Gang of Four. Элементы многократно используемого ОО-ПО",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    InStock = true
                },
                new Product
                {
                    Name = "Книга «C# 10. Справочник»",
                    Price = 1500,
                    Category = "Книги",
                    Description = "Алибахов. Полное руководство по языку C#",
                    CreatedDate = DateTime.Now.AddDays(-25),
                    InStock = false
                },
                new Product
                {
                    Name = "Книга «Алгоритмы. Построение и анализ»",
                    Price = 2400,
                    Category = "Книги",
                    Description = "Кормен, Лейзерсон. Классика алгоритмики",
                    CreatedDate = DateTime.Now.AddDays(-50),
                    InStock = true
                },
                new Product
                {
                    Name = "Кресло игровое DXRacer Formula",
                    Price = 35000,
                    Category = "Мебель",
                    Description = "Эргономичное кресло с поддержкой поясницы",
                    CreatedDate = DateTime.Now.AddDays(-40),
                    InStock = true
                },
                new Product
                {
                    Name = "Стол компьютерный L-образный",
                    Price = 22000,
                    Category = "Мебель",
                    Description = "180x120 см, ЛДСП, регулируемые ножки",
                    CreatedDate = DateTime.Now.AddDays(-70),
                    InStock = false
                },
                new Product
                {
                    Name = "Гантели разборные 30кг",
                    Price = 5500,
                    Category = "Спорт",
                    Description = "Стальные, резиновые накладки, в комплекте гриф",
                    CreatedDate = DateTime.Now.AddDays(-12),
                    InStock = true
                },
                new Product
                {
                    Name = "Коврик для йоги Pro",
                    Price = 2800,
                    Category = "Спорт",
                    Description = "NBR, 183x61 см, толщина 10мм, нескользящий",
                    CreatedDate = DateTime.Now.AddDays(-8),
                    InStock = true
                },
                new Product
                {
                    Name = "Велотренажёр Kettler Axos",
                    Price = 42000,
                    Category = "Спорт",
                    Description = "8 уровней нагрузки, пульсометр, ЖК-дисплей",
                    CreatedDate = DateTime.Now.AddDays(-55),
                    InStock = false
                },
                new Product
                {
                    Name = "Куртка зимняя Columbia",
                    Price = 14000,
                    Category = "Одежда",
                    Description = "Утеплитель Omni-Heat, водоотталкивающая, р. M",
                    CreatedDate = DateTime.Now.AddDays(-35),
                    InStock = true
                },
                new Product
                {
                    Name = "Кроссовки Nike Air Max 270",
                    Price = 11000,
                    Category = "Одежда",
                    Description = "Air-подушка, сетчатый верх, р. 42",
                    CreatedDate = DateTime.Now.AddDays(-18),
                    InStock = true
                },
                new Product
                {
                    Name = "Рюкзак Osprey Talon 22",
                    Price = 9800,
                    Category = "Одежда",
                    Description = "22L, дышащая спинка, для трекинга",
                    CreatedDate = DateTime.Now.AddDays(-22),
                    InStock = true
                },
                new Product
                {
                    Name = "Мышь Logitech G Pro X Superlight",
                    Price = 8500,
                    Category = "Электроника",
                    Description = "Беспроводная, 25600 DPI, 61г, HERO sensor",
                    CreatedDate = DateTime.Now.AddDays(-7),
                    InStock = true
                },
                new Product
                {
                    Name = "Монитор Samsung 27\" Odyssey G5",
                    Price = 32000,
                    Category = "Электроника",
                    Description = "2560x1440, 165Гц, 1ms, VA, HDR10, FreeSync",
                    CreatedDate = DateTime.Now.AddDays(-100),
                    InStock = false
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
