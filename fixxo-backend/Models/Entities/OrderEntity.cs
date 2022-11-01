using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace fixxo_backend.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ProductEntity> products { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Adress { get; set; }



    }
}
