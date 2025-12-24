namespace Core.ViewModels.Request.Filters
{
    public class WeaponFiltering : IFiltering
    {
        public List<int> MagazineCapacities { get; set; }
        public List<string> SightingDevices { get; set; }
        public List<string> GunStockAndButts { get; set; }
        public List<int> InitialVelocities { get; set; }
        public List<string> BarrelTwists { get; set; }
        public List<string> Calibers { get; set; }
    }
}
