using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_API_TakeTwo.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Produkten måste innehålla fler bokstäver.")]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public Category Category { get; set; }
    }
}
