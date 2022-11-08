using fixxo_backend.Models.Entities;

namespace fixxo_backend.Models
{

    public class ProductColorRequest
    {
        public string ImgUrl { get; set; }
        public Colors Color { get; set; }
        public int ProductId { get; set; }
    }
}
