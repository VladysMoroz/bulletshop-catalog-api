using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels;
using Core.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColdWeaponController : ControllerBase
    {
        private readonly IColdWeaponService _coldWeaponService;
        private readonly IMapper _mapper;

        public ColdWeaponController(IColdWeaponService coldWeaponService, IMapper mapper)
        {
            _coldWeaponService = coldWeaponService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeaponAsync([FromBody] ColdWeaponViewModel productWeapon)
        {
            var coldWeapon = _mapper.Map<ColdWeaponViewModel, ColdWeapon>(productWeapon);

            var dbWeapon = await _coldWeaponService.CreateAsync(coldWeapon);

            return Ok(dbWeapon);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColdWeaponsAsync()
        {
            var weapons = await _coldWeaponService.GetAllAsync();

            var weaponViewModels = _mapper.Map<List<ColdWeapon>, List<ColdWeaponViewModel>>(weapons);
            return Ok(weaponViewModels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeaponAsync(int id, [FromBody] ColdWeaponViewModel productColdWeapon)
        {
            var coldWeapon = _mapper.Map<ColdWeaponViewModel, ColdWeapon>(productColdWeapon);

            var updatedColdWeapon = await _coldWeaponService.UpdateAsync(id, coldWeapon);

            return Ok(updatedColdWeapon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponAsync(int id)
        {
            await _coldWeaponService.DeleteAsync(id);

            return Ok("ColdWeapon was deleted successfully");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetItemsByFilterAsync([FromBody] ColdWeaponRequest request)
        {
            var coldWeapons = await _coldWeaponService.GetColdWeaponsByFilterAsync(request);

            return Ok(coldWeapons);
        }
    }
}
