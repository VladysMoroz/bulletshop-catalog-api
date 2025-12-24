using ApplicationServices.Services;
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
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        private readonly IMapper _mapper;

        public WeaponController(IWeaponService weaponService, IMapper mapper)
        {
            _weaponService = weaponService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeaponAsync([FromBody] WeaponViewModel productWeapon)
        {
            var weapons = _mapper.Map<WeaponViewModel, Weapon>(productWeapon);

            var dbWeapon = await _weaponService.CreateAsync(weapons);

            return Ok(dbWeapon);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWeaponsAsync()
        {
            var weapons = await _weaponService.GetAllAsync();

            var weaponViewModels = _mapper.Map<List<Weapon>, List<WeaponViewModel>>(weapons);
            return Ok(weaponViewModels);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeaponAsync(int id, [FromBody] WeaponViewModel productWeapon)
        {
            var weapons = _mapper.Map<WeaponViewModel, Weapon>(productWeapon);

            var updatedWeapon = await _weaponService.UpdateAsync(id, weapons);

            return Ok(updatedWeapon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponAsync(int id)
        {
            await _weaponService.DeleteAsync(id);

            return Ok("Weapon was deleted succesfully");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetItemsByFilterAsync([FromBody] WeaponRequest request)
        {
            var weapons = await _weaponService.GetWeaponsByFilterAsync(request);

            return Ok(weapons);
        }

        [HttpGet("CompareTwoItems")]
        public async Task<IActionResult> GetTwoItemsForCompare(int item1, int item2)
        {
            var weapons = new List<Weapon>();

            var weapon1 = await _weaponService.GetByIdAsync(item1);

            var weapon2 = await _weaponService.GetByIdAsync(item2);

            weapons.Add(weapon1);
            weapons.Add(weapon2);

            return Ok(weapons);
        }
    }
}
