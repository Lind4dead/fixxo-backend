namespace fixxo_backend.Models.Entities
{
    public enum Colors
    {
        Gray,
        Black,
        Red,
        Blue,
        Green,
        White,
        Yellow,
        Purple
    }
    public class ProductColorEntity
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public virtual Colors Color { get; set; }
    }
}
