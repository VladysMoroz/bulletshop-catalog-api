using Core.ViewModels.Request.Filters;

namespace Core.ViewModels.Request
{
    public class OpticRequest
    {
        public Sorting Sorting { get; set; }
        public Pagination Pagination { get; set; }
        public OpticFiltering Filtering { get; set; }
    }
}
