namespace Core.ViewModels.Request.Filters
{
    public class ColdWeaponFiltering : IFiltering
    {
        public List<string> HandleMaterials { get; set; }
        public List<string> BladeMaterials { get; set; }
        public List<int> HardnessMaterials { get; set; }
        public List<string> Locks { get; set; }
    }
}
