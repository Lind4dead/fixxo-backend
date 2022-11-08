namespace fixxo_backend.Models
{
    public class ProductSingleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<ProductSingleColorResponse> Colors { get; set; }
        public ICollection<ProductSingleSizeResponse> Sizes { get; set; }
        public ICollection<AdditionalInformationResponse> AdditionalInformationResponses { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
