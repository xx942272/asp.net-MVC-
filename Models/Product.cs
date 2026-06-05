using System.ComponentModel.DataAnnotations;

namespace s14112310482.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Difficulty { get; set; }
        [Required]
        public string ImgF { get; set; }
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
