namespace fixxo_backend.Models.Entities
{
    public class OrderProductEntity
    {
        public int Id { get; set; }
       
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Total { get; set; }
        public ICollection<OrderEntity> OrderEntity { get; set; }
        public ICollection<ProductEntity> Product { get; set; }
    }





}
