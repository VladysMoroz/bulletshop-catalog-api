using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace ApplicationServices.Services
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IPreferenceRepository _preferenceRepository;

        public PreferenceService(IPreferenceRepository preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        public async Task CreatePreferencesAsync(Preference preferences)
        {
            await _preferenceRepository.CreatePreferencesAsync(preferences);
        }

        public async Task DeletePreferencesAsync(Preference preferences)
        {
            await _preferenceRepository.DeletePreferencesAsync(preferences);
        }

        public async Task<List<Preference>> GetPreferencesByUserIdAsync(Guid userId)
        {
            var preferences = await _preferenceRepository.GetPreferencesByUserIdAsync(userId);

            return preferences;
        }
    }
}
