using fixxo_backend.Models.Entities;

namespace fixxo_backend.Models
{
    public class ProductColorResponse
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string ColorName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
