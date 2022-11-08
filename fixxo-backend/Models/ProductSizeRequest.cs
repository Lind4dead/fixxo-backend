using fixxo_backend.Models.Entities;

namespace fixxo_backend.Models
{
    public class ProductSizeRequest
    {
        public Sizes Size { get; set; }
        public int ProductId { get; set; }
    }
}
