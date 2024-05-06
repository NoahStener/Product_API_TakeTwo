using Product_API_TakeTwo.Models;

namespace Product_API_TakeTwo.Services
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetSingle(int id);
        Task<Product> Add(Product newProduct);
        Task<Product> Update(Product updateProduct);
        Task<Product> Delete(int id);
        Task<IEnumerable<Product>> SearchProductByName(string productName);
        Task<Review> AddReview(Review review);
        Task<List<Review>> GetReviews(int productId);
        Task<Product> Purchase(int productId, int quantity);
    }
}
