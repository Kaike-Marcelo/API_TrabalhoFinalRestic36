namespace ApiPedidin.Models
{
    public class Orders_ProductsModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
    }
}