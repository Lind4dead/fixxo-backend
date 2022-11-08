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
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICollection<ProductColorEntity> Colors { get; set; }

        public ICollection<ProductSizeEntity> Sizes { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }

        public virtual ICollection<AdditionalInformationEntity> AdditionalInformation { get; set; }





    }
}
