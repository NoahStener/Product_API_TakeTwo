using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API_TakeTwo.Models;
using Product_API_TakeTwo.Services;

namespace Product_API_TakeTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _productRepo;
        public ProductController(IProduct productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productRepo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}GetSingleProduct")]
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            try
            {
                var result = await _productRepo.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:int}UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product updateProduct)
        {
            try
            {
                if (id != updateProduct.ProductID)
                {
                    return BadRequest("No product found with given ID");
                }

                var productToUpdate = await _productRepo.GetSingle(id);
                if (productToUpdate == null)
                {
                    return NotFound($"Product with ID {id} not found");
                }

                return await _productRepo.Update(updateProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}DeleteProduct")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var result = await _productRepo.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPost("{newProduct}AddNewProduct")]
        public async Task<ActionResult<Product>> AddNewProduct(Product newProduct)
        {
            try
            {
                var product = await _productRepo.Add(newProduct);
                if (product == null)
                {
                    return BadRequest("kunde inte lägga till produkten");
                }
                return CreatedAtAction(nameof(GetSingleProduct), new { id = product.ProductID }, product);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productName}Search")]
        public async Task<IActionResult> Search(string productName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productName))
                {
                    return BadRequest("produkt måste anges");
                }

                var products = await _productRepo.SearchProductByName(productName);
                if (products == null || !products.Any())
                {
                    return NotFound("Inga produkter hittades med det namnet");
                }

                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productID}/Reviews")]
        public async Task<ActionResult<Review>> GetReviewForProduct(int productID)
        {
            try
            {
                var reviews = await _productRepo.GetReviews(productID);
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound($"Inga rescensioner hittades med ID {productID}");
                }
                return Ok(reviews);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddReview")]
        public async Task<ActionResult<Review>> AddReviewForProduct(Review review)
        {

            try
            {
                var newReview = await _productRepo.AddReview(review);
                if(newReview == null)
                {
                    return NotFound("kunda inte lägga till rescension");
                }
                return CreatedAtAction(nameof(GetSingleProduct), new {id = newReview.ProductID}, newReview);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("purchase/{productId}")]
        public async Task<IActionResult> PurchaseProduct(int productId, int quantity)
        {
            try
            {
                var product = await _productRepo.Purchase(productId, quantity);
                if(product == null)
                {
                    return NotFound("Produkt finns ej eller är slut i lager");
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
