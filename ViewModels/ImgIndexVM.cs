using s14112310482.Models;

namespace s14112310482.ViewModels
{
    public class ImgIndexVM
    {
        public IEnumerable<ImgCarousel> ImgList { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
        public string SrhKey { get; set; }
    }
}
