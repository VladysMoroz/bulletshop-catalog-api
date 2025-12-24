using Core.Entities;
using Core.ViewModels.Request;
using Core.ViewModels.Request.Filters;

namespace Core.Interfaces.Repositories
{
    public interface IColdWeaponRepository : IRepository<ColdWeapon>
    {
        Task<List<ColdWeapon>> GetItemsByFilterAsync(ColdWeaponFiltering filtering, Sorting sorting, Pagination pagination);
    }
}
