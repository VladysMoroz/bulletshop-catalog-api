using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IPreferenceService
    {
        public Task<List<Preference>> GetPreferencesByUserIdAsync(Guid userId);

        public Task CreatePreferencesAsync(Preference preferences);

        public Task DeletePreferencesAsync(Preference preferences);
    }
}
