namespace fixxo_backend.Models
{
    public class OrderRequest
    {
        public int ProductId { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
