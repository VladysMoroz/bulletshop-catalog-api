using Core.ViewModels.Request.Filters;

namespace Core.ViewModels.Request
{
    public class WeaponRequest
    {
        public Sorting Sorting { get; set; }
        public Pagination Pagination { get; set; }
        public WeaponFiltering Filtering { get; set; }
    }
}
