namespace ApiPedidin.Models
{
    public class ProductsModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? PathImage { get; set; }
        public string? Price { get; set; }
        public string? BaseDescription { get; set; }
        public string? FullDescription { get; set; }
        public long CategoryId { get; set; }
    }
}