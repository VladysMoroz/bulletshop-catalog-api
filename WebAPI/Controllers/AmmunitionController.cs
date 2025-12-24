using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels;
using Core.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmmunitionController : ControllerBase
    {
        private readonly IAmmunitionService _ammunitionService;
        private readonly IMapper _mapper;

        public AmmunitionController(IAmmunitionService ammunitionService, IMapper mapper)
        {
            _ammunitionService = ammunitionService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAmmunitionAsync([FromBody] AmmunitionViewModel productAmmunition)
        {
            var ammunition = _mapper.Map<AmmunitionViewModel, Ammunition>(productAmmunition);

            var dbAmmunition = await _ammunitionService.CreateAsync(ammunition);

            return Ok(dbAmmunition);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAmmunitionsAsync()
        {
            var ammunitions = await _ammunitionService.GetAllAsync();

            var AmmunitionViewModels = _mapper.Map<List<Ammunition>, List<AmmunitionViewModel>>(ammunitions);
            return Ok(AmmunitionViewModels);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAmmunitionAsync(int id, [FromBody] AmmunitionViewModel productAmmunition)
        {
            var ammunition = _mapper.Map<AmmunitionViewModel, Ammunition>(productAmmunition);


            var updatedAmmunition = await _ammunitionService.UpdateAsync(id, ammunition);

            return Ok(updatedAmmunition);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAmmunitionAsync(int id)
        {
            await _ammunitionService.DeleteAsync(id);

            return Ok("Ammunition has been deleted succesfully");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetItemsByFilterAsync([FromBody] AmmunitionRequest request)
        {
            var ammunitions = await _ammunitionService.GetAmmunitionsByFilterAsync(request);

            return Ok(ammunitions);
        }
    }
}
