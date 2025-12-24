using Core.Entities;
using Core.ViewModels.Request;

namespace Core.Interfaces.Services
{
    public interface IAmmunitionService : IService<Ammunition>
    {
        public Task<List<Ammunition>> GetAmmunitionsByFilterAsync(AmmunitionRequest request);
    }
}
