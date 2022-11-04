using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace fixxo_backend.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }




        public ICollection<ProductColorEntity> Colors { get; set; }
               

        public virtual CategoryEntity Category { get; set; }

        




    }
}
