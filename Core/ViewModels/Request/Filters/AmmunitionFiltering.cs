namespace Core.ViewModels.Request.Filters
{
    public class AmmunitionFiltering : IFiltering
    {
        public List<string> Colors { get; set; }
        public List<string> ProtectionLevels { get; set; }
        public List<string> Seasons { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Genders { get; set; }
    }
}
