using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]

        public Order Order { get; set; }
        [JsonIgnore]

        public Product Product { get; set; }
    }
}
