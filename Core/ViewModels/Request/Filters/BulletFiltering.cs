using System.Net;

namespace Core.ViewModels.Request.Filters
{
    public class BulletFiltering : IFiltering
    {
        public List<string> Calibers { get; set; }
        public List<decimal> BulletWeights { get; set; }
        public List<int> QuantityInPackages  { get; set; }
    }
}
