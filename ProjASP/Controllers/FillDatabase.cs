using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProjASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillDatabase : Controller
    {
        [HttpPost]
        public IActionResult Post()
        {
            var _context = new AspProjContext();


            // Seed Users
            var users = new[]
            {
                new User { Email = "user1@example.com", Username = "user1", FirstName = "First", LastName = "User", Password = "password1", BirthDate = new DateTime(1990, 1, 1), CreatedAt = DateTime.UtcNow },
                new User { Email = "user2@example.com", Username = "user2", FirstName = "Second", LastName = "User", Password = "password2", BirthDate = new DateTime(1991, 2, 2), CreatedAt = DateTime.UtcNow }
            };
            _context.Users.AddRange(users);
            _context.SaveChanges();
            // Seed Brands
            var brands = new[]
            {
                new Brand { Name = "Brand1", CreatedAt = DateTime.UtcNow },
                new Brand { Name = "Brand2", CreatedAt = DateTime.UtcNow }
            };
            _context.Brands.AddRange(brands);
            _context.SaveChanges();
            // Seed Models
            var models = new[]
            {
                new Model { Name = "Model1", Description = "Description1", brandId = brands[0].Id, RamMemory = 4, StorageMemory = 64, CameraMegapixels = 12, CreatedAt = DateTime.UtcNow },
                new Model { Name = "Model2", Description = "Description2", brandId = brands[1].Id, RamMemory = 8, StorageMemory = 128, CameraMegapixels = 16, CreatedAt = DateTime.UtcNow }
            };
            _context.Models.AddRange(models);
            _context.SaveChanges();
            // Seed Colors
            var colors = new[]
            {
                new Color { Name = "Red", CreatedAt = DateTime.UtcNow },
                new Color { Name = "Blue", CreatedAt = DateTime.UtcNow }
            };
            _context.Colors.AddRange(colors);
            _context.SaveChanges();
            // Seed ModelColors
            var modelColors = new[]
            {
                new ModelColor { ModelId = models[0].Id, ColorId = colors[0].Id, CreatedAt = DateTime.UtcNow },
                new ModelColor { ModelId = models[1].Id, ColorId = colors[1].Id, CreatedAt = DateTime.UtcNow }
            };
            _context.ModelColors.AddRange(modelColors);
            _context.SaveChanges();
            // Seed Prices
            var prices = new[]
            {
                new Price { PriceValue = 499.99m, ModelColorId = modelColors[0].Id, CreatedAt = DateTime.UtcNow },
                new Price { PriceValue = 699.99m, ModelColorId = modelColors[1].Id, CreatedAt = DateTime.UtcNow }
            };
            _context.Prices.AddRange(prices);
            _context.SaveChanges();
            // Seed Images
            var images = new[]
            {
                new Image { ImageName = "Image1", ImageUrl = "image1.jpg", ModelId = models[0].Id, CreatedAt = DateTime.UtcNow },
                new Image { ImageName = "Image2", ImageUrl = "image2.jpg", ModelId = models[1].Id, CreatedAt = DateTime.UtcNow }
            };
            _context.Images.AddRange(images);
            _context.SaveChanges();
            // Seed Carts
            var carts = new[]
            {
                new Cart { UserId = users[0].Id, CreatedAt = DateTime.UtcNow },
                new Cart { UserId = users[1].Id, CreatedAt = DateTime.UtcNow }
            };
            _context.Carts.AddRange(carts);
            _context.SaveChanges();
            // Seed ProductCarts
            var productCarts = new[]
            {
                new ProductCart { Quanity = 2, ModelColorId = modelColors[0].Id, CartId = carts[0].Id, CreatedAt = DateTime.UtcNow },
                new ProductCart { Quanity = 1, ModelColorId = modelColors[1].Id, CartId = carts[1].Id, CreatedAt = DateTime.UtcNow }
            };
            _context.ProductCarts.AddRange(productCarts);

            _context.SaveChanges();
            return Ok("Database seeded successfully.");
        }
    }
}
