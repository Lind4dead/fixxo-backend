namespace fixxo_backend.Models
{
    public class OrderProductEntityRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Total { get; set; }
    }
}
