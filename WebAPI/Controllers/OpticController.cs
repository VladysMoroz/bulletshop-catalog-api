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
    public class OpticController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOpticService _opticService;
        public OpticController(IMapper mapper, IOpticService opticService)
        {
            _mapper = mapper;
            _opticService = opticService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOpticAsync([FromBody] OpticViewModel productOptic)
        {
            var optic = _mapper.Map<OpticViewModel, Optic>(productOptic);

            var dbWeapon = await _opticService.CreateAsync(optic);

            return Ok(dbWeapon);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOpticsAsync()
        {
            var optics = await _opticService.GetAllAsync();

            var opticViewModels = _mapper.Map<List<Optic>, List<OpticViewModel>>(optics);
            return Ok(opticViewModels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOpticAsync(int id, [FromBody] OpticViewModel productOptic)
        {

            var optic = _mapper.Map<OpticViewModel, Optic>(productOptic);


            var updatedOptic = await _opticService.UpdateAsync(id, optic);

            return Ok(updatedOptic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpticAsync(int id)
        {
            await _opticService.DeleteAsync(id);

            return Ok("Optic was deleted succesfully");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetItemsByFilterAsync([FromBody] OpticRequest request)
        {
            var optics = await _opticService.GetOpticsByFilterAsync(request);

            return Ok(optics);
        }
    }
}
