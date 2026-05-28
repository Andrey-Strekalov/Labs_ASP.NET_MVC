using ASP.NET_MVC_LABs.Data;
using ASP.NET_MVC_LABs.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 .LogTo(Console.WriteLine, LogLevel.Information) // Логирование SQL
 .EnableSensitiveDataLogging() // Показывать параметры
);


builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IGameRepository, EfGameRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await SeedDataProduct.InitializeAsync(dbContext);
    await SeedDataGames.InitializeAsync(dbContext);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Кастомный маршрут 1
app.MapControllerRoute(
    name: "about",
    pattern: "about-us",
    defaults: new { controller = "Home", action = "Privacy" });

// Кастомный маршрут 2
app.MapControllerRoute(
    name: "userProfile",
    pattern: "user/{username}/{action=Profile}",
    defaults: new { controller = "Demo" });

// Маршрут с ограничениями 
app.MapControllerRoute(
    name: "product",
    pattern: "product/{id:int}",
    defaults: new { controller = "Demo", action = "ProductDetails" });


app.Run();
