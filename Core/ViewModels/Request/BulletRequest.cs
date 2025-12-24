using Core.ViewModels.Request.Filters;

namespace Core.ViewModels.Request
{
    public class BulletRequest
    {
        public Sorting Sorting { get; set; }
        public Pagination Pagination { get; set; }
        public BulletFiltering Filtering { get; set; }
    }
}
