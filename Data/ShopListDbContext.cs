using Microsoft.EntityFrameworkCore;
using ShopListBackend.Models;

namespace ShopListBackend.Data;

public class ShopListDbContext : DbContext
{
    public ShopListDbContext(DbContextOptions<ShopListDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        // Seed data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "חלב וגבינות" },
            new Category { Id = 2, Name = "טואלטיקה" },
            new Category { Id = 3, Name = "בשר" },
            new Category { Id = 4, Name = "ירקות ופירות" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "קוטג", CategoryId = 1 },
            new Product { Id = 2, Name = "חלב 3%", CategoryId = 1 },
            new Product { Id = 3, Name = "שמנת חמוצה", CategoryId = 1 },
            new Product { Id = 4, Name = "יוגורט", CategoryId = 1 },
            new Product { Id = 5, Name = "סבון", CategoryId = 2 },
            new Product { Id = 6, Name = "שמפו", CategoryId = 2 },
            new Product { Id = 7, Name = "נייר טואלט", CategoryId = 2 },
            new Product { Id = 8, Name = "בקר", CategoryId = 3 },
            new Product { Id = 9, Name = "עוף", CategoryId = 3 },
            new Product { Id = 10, Name = "הודו", CategoryId = 3 },
            new Product { Id = 11, Name = "כבש", CategoryId = 3 },
            new Product { Id = 12, Name = "גזר", CategoryId = 4 },
            new Product { Id = 13, Name = "מנגו", CategoryId = 4 },
            new Product { Id = 14, Name = "אבטיח", CategoryId = 4 }
        );
    }
}