using Microsoft.EntityFrameworkCore;
using Product_API_TakeTwo.Data;
using Product_API_TakeTwo.Models;

namespace Product_API_TakeTwo.Services
{
    public class ProductRepo : IProduct
    {
        private ProductDBContext _productDbContext;
        public ProductRepo(ProductDBContext productDBContext) 
        {
            _productDbContext = productDBContext;
        }
        //POST
        public async Task<Product> Add(Product newProduct)
        {
            var result = await _productDbContext.Products.AddAsync(newProduct);
            await _productDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //DELETE
        public async Task<Product> Delete(int id)
        {
            var result = await _productDbContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if(result != null)
            {
                _productDbContext.Products.Remove(result);
                await _productDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //GET
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingle(int id)
        {
            return await _productDbContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        //PUT
        public async Task<Product> Update(Product updateProduct)
        {
            var result = await _productDbContext.Products.FirstOrDefaultAsync(p => p.ProductID == updateProduct.ProductID);
            if(result != null )
            {
                result.ProductName = updateProduct.ProductName;
                result.ProductDescription = updateProduct.ProductDescription;
                result.Price = updateProduct.Price;
                result.AmountInStock = updateProduct.AmountInStock;

                await _productDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //GET
        public async Task<IEnumerable<Product>> SearchProductByName(string productName)
        {
            return await _productDbContext.Products
                .Where(p => p.ProductName.Contains(productName))
                .ToListAsync();
        }

        //Review funktioner
        public async Task<Review>AddReview(Review review)
        {
            _productDbContext.Reviews.Add(review);
            await _productDbContext.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetReviews(int productId)
        {
            return await _productDbContext.Reviews
                .Where(r => r.ProductID == productId)
                .ToListAsync();
        }

        //Handla Produkt funktion
        public async Task<Product> Purchase(int productId , int quantity)
        {
            var product = await _productDbContext.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
            if(product == null || product.AmountInStock < quantity)
            {
                return null;
            }
            
            product.AmountInStock -= quantity;
            await _productDbContext.SaveChangesAsync();
            return product;
        }
    }
}
