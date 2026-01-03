using AICleanArchitectureDemo.Application;
using AICleanArchitectureDemo.Domain.Entities;
using AICleanArchitectureDemo.Domain.Interfaces;
using AICleanArchitectureDemo.Infrastructure;
using AICleanArchitectureDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

// Register layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Apply database migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var categoryRepo = scope.ServiceProvider.GetRequiredService<IRepository<Category>>();
    var productRepo = scope.ServiceProvider.GetRequiredService<IRepository<Product>>();

    // Seed categories
    if (!context.Categories.Any())
    {
        var electronics = new Category { Name = "Electronics", Description = "Electronic devices and gadgets" };
        var clothing = new Category { Name = "Clothing", Description = "Fashion and apparel" };
        var books = new Category { Name = "Books", Description = "Books and publications" };

        categoryRepo.AddAsync(electronics).Wait();
        categoryRepo.AddAsync(clothing).Wait();
        categoryRepo.AddAsync(books).Wait();

        // Seed products
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, CategoryId = electronics.Id, StockQuantity = 50, ImageUrl = "laptop.jpg" },
            new Product { Name = "Smartphone", Description = "Latest smartphone", Price = 699.99m, CategoryId = electronics.Id, StockQuantity = 100, ImageUrl = "phone.jpg" },
            new Product { Name = "T-Shirt", Description = "Cotton T-shirt", Price = 19.99m, CategoryId = clothing.Id, StockQuantity = 200, ImageUrl = "tshirt.jpg" },
            new Product { Name = "Programming Book", Description = "Learn C# programming", Price = 49.99m, CategoryId = books.Id, StockQuantity = 75, ImageUrl = "book.jpg" }
        };

        foreach (var product in products)
        {
            productRepo.AddAsync(product).Wait();
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
