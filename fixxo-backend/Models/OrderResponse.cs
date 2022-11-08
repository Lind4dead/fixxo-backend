namespace fixxo_backend.Models
{
    public class OrderResponse
    {
         public int Id { get; set; }
        public int ProductId { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
