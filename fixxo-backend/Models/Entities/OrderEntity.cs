using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<OrderProductEntity> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }

    }
}
