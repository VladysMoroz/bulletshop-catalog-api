using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public string StatusUA { get; set; } = "Активний";
        public string StatusENG { get; set; } = "Active";
        public string DeliveryAdress { get; set; }
        public Guid UserId { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
