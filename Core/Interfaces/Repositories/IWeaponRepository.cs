using Core.Entities;
using Core.ViewModels.Request.Filters;
using Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IWeaponRepository : IRepository<Weapon>
    {
        Task<List<Weapon>> GetItemsByFilterAsync(WeaponFiltering filtering, Sorting sorting, Pagination pagination);
    }
}
