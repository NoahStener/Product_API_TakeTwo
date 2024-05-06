using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Product_API_TakeTwo.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        [Required]
        public string Comment { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        public int ProductID { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
