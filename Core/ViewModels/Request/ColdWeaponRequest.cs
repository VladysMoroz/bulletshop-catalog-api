using Core.ViewModels.Request.Filters;

namespace Core.ViewModels.Request
{
    public class ColdWeaponRequest
    {
        public Pagination Pagination { get; set; }
        public Sorting Sorting { get; set; }
        public ColdWeaponFiltering Filtering { get; set; }
    }
}
