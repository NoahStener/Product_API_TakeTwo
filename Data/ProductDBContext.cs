using Microsoft.EntityFrameworkCore;
using Product_API_TakeTwo.Models;

namespace Product_API_TakeTwo.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base (options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Datorer
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                ProductName = "Gaming PC v1",
                ProductDescription = "Decent PC",
                Price = 15000.00m,
                AmountInStock = 10,
                Category = Category.Computer
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 2,
                ProductName = "Gaming PC v2",
                ProductDescription = "Average PC",
                Price = 20000.00m,
                AmountInStock = 12,
                Category = Category.Computer
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 3,
                ProductName = "Gaming PC v3",
                ProductDescription = "Good PC",
                Price = 25000.00m,
                AmountInStock = 8,
                Category = Category.Computer
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 4,
                ProductName = "Gaming PC v4",
                ProductDescription = "Very good PC",
                Price = 30000.00m,
                AmountInStock = 5,
                Category = Category.Computer
            });


            //Kläder
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 5,
                ProductName = "T-Shirt",
                ProductDescription = "Black color",
                Price = 300.00m,
                AmountInStock = 20,
                Category = Category.Clothing
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 6,
                ProductName = "Jeans",
                ProductDescription = "Light blue color",
                Price = 600.00m,
                AmountInStock = 15,
                Category = Category.Clothing
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 7,
                ProductName = "Shirt",
                ProductDescription = "White color",
                Price = 700.00m,
                AmountInStock = 10,
                Category = Category.Clothing
            });
        }
    }
}
