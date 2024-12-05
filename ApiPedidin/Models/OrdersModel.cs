using System.Globalization;

namespace ApiPedidin.Models
{
    public class OrdersModel
    {
        public long Id { get; set; }
        public long statusId { get; set; }
        public float value { get; set; }
    }
}