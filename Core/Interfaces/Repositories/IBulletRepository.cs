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
    public interface IBulletRepository : IRepository<Bullet>
    {
        Task<List<Bullet>> GetItemsByFilterAsync(BulletFiltering filtering, Sorting sorting, Pagination pagination);
    }
}
