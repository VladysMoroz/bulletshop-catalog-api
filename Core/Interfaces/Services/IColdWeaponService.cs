using Core.Entities;
using Core.ViewModels.Request;

namespace Core.Interfaces.Services
{
    public interface IColdWeaponService : IService<ColdWeapon>
    {
        public Task<List<ColdWeapon>> GetColdWeaponsByFilterAsync(ColdWeaponRequest request);
    }
}
