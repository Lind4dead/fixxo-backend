using Microsoft.CodeAnalysis.Classification;

namespace fixxo_backend.Models.Entities
{
    public class AdditionalInformationEntity
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int ClassificationId { get; set; }
        public ClassificationEntity Classification { get; set; }
    }
}
