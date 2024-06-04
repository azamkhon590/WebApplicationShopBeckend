using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBackend.Model
{
    public class Product
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}
