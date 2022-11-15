namespace fixxo_backend.Models
{
    public class OrderProductEntityResponse
    {
         
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Total { get; set; }
    }
}
