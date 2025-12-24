using Core.Entities;
using Core.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IWeaponService : IService<Weapon>
    {
        public Task<List<Weapon>> GetWeaponsByFilterAsync(WeaponRequest request);
    }
}
