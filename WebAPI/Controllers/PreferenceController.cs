using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceService _preferenceService;
        private readonly IMapper _mapper;

        public PreferenceController(IPreferenceService preferenceService, IMapper mapper)
        {
            _preferenceService = preferenceService;

            _mapper = mapper;
        }

        [HttpGet("GetPreferencesById")]
        public async Task<IActionResult> GetPreferencesByIdAsync(Guid userid)
        {
            var preferences = await _preferenceService.GetPreferencesByUserIdAsync(userid);

            return Ok(preferences);
        }

        [HttpPost("AddUserPreferences")]
        public async Task<IActionResult> AddUserPreferencesAsync(PreferenceViewModel preference)
        {
            var newPreference = _mapper.Map<PreferenceViewModel, Preference>(preference);

            await _preferenceService.CreatePreferencesAsync(newPreference);

            return Ok("Preference has been created successfully");
        }

        [HttpDelete("DeletePreferences")]
        public async Task<IActionResult> DeletePreferences(PreferenceViewModel preference)
        {
            var preferenceForDelete = _mapper.Map<PreferenceViewModel, Preference>(preference);

            await _preferenceService.DeletePreferencesAsync(preferenceForDelete);

            return Ok("Preferences was deleted successfully");
        }
    }
}
