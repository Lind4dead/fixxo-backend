namespace fixxo_backend.Models.Entities
{
    public enum Sizes
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL
    }
    public class ProductSizeEntity
    {
        public int Id { get; set; }
        public Sizes Size { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}
