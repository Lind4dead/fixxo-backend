namespace fixxo_backend.Models.Entities
{
    public class OrderProductEntity
    {
        public int Id { get; set; }
       
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Total { get; set; }
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }
    }





}
