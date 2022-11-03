using fixxo_backend.Models.Entities;

namespace fixxo_backend.Models
{
    public class ProductSizeResponse
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
