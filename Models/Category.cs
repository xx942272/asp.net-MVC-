using System.ComponentModel.DataAnnotations;
namespace s14112310482.Models

{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "類別名稱必填")]
        [MaxLength(50)]
        [Display(Name = "類別名稱")]
        public string Name { get; set; }
        [Display(Name = "顯示順序")]
        [Range(1, 100, ErrorMessage = "輸入的範圍應該在1~100之間")]
        public int DisplayOrder { get; set; }
        [Display(Name = "備註")]
        public string? Memo { get; set; }
    }
}
