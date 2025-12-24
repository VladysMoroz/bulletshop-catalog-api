using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class OrderViewModel
    {
        public string DeliveryAdress { get; set; }
        public Guid UserId { get; set; }
        public List<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}
