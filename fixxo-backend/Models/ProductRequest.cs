namespace fixxo_backend.Models
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductColorRequest Color { get; set; }
        public int CategoryId { get; set; }
    }
}
