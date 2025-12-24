using Core.ViewModels.Request.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels.Request
{
    public class AmmunitionRequest
    {
        public Sorting Sorting { get; set; }
        public Pagination Pagination { get; set; }
        public AmmunitionFiltering Filtering { get; set; }
    }
}
