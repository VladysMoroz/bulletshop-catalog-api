using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCatalog.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private readonly CatalogDbContext _dbContext;

        public PreferenceRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePreferencesAsync(Preference preferences)
        {
            _dbContext.Preferences.Add(preferences);

            await _dbContext.SaveChangesAsync();

        }

        public async Task DeletePreferencesAsync(Preference preferences)
        {
            _dbContext.Preferences.Remove(preferences);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Preference>> GetPreferencesByUserIdAsync(Guid userid)
        {
            var preferences = _dbContext.Preferences
                                  .Where(p => p.UserId == userid)
                                  .Include(p => p.Product)
                                  .ToList();
            return preferences;
        }
    }
}
