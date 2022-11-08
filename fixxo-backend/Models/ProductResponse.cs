using fixxo_backend.Models.Entities;

namespace fixxo_backend.Models
{
    public class ProductResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
