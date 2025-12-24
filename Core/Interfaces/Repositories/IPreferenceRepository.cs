using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPreferenceRepository
    {
        public Task<List<Preference>> GetPreferencesByUserIdAsync(Guid userid);

        public Task DeletePreferencesAsync(Preference preferences);

        public Task CreatePreferencesAsync(Preference preferences);
    }
}
