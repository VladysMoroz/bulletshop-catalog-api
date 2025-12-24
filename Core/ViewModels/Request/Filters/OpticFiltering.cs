namespace Core.ViewModels.Request.Filters
{
    public class OpticFiltering : IFiltering
    {
        public List<string> RingDiameters { get; set; }
        public List<string> Multiplicities { get; set; }
        public List<int> ObjectiveLensDiameters { get; set; }
        public List<string> ReticleTypes { get; set; }
        public List<string> Focusings { get; set; }
        public bool? ReticleIllumination { get; set; }

    }
}
