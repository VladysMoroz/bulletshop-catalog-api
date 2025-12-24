using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Preference
    {
        public Guid UserId  { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
