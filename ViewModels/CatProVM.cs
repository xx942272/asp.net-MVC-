using s14112310482.Models;
using s14112310482.Services;

namespace s14112310482.ViewModels
{
    public class CatProVM
    {
        public int SrhId { get; set; }
        public string? SrhName { get; set; }
        public List<Category>? CategoryList { get; set; }
        public List<Product>? ProductList { get; set; }
   
    // 宣告一個 ForPaging 類別的物件
        public ForPaging Paging { get; set; }
    }
}