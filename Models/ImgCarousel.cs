using System.ComponentModel.DataAnnotations;

namespace s14112310482.Models

{
    public class ImgCarousel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImgF { get; set; }
    }
}