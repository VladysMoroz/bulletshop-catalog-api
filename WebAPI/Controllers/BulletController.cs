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
    public class BulletController : ControllerBase
    {
        private readonly IBulletService _bulletService;
        private readonly IMapper _mapper;

        public BulletController(IBulletService bulletService, IMapper mapper)
        {
            _bulletService = bulletService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBulletAsync([FromBody] BulletViewModel productBullet)
        {
            var bullet = _mapper.Map<BulletViewModel, Bullet>(productBullet);

            var dbBullet = await _bulletService.CreateAsync(bullet);

            return Ok(dbBullet);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBulletsAsync()
        {
            var bullets = await _bulletService.GetAllAsync();

            var bulletViewModels = _mapper.Map<List<Bullet>, List<BulletViewModel>>(bullets);
            return Ok(bulletViewModels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBulletAsync(int id, [FromBody] BulletViewModel productBullet)
        {

            var bullet = _mapper.Map<BulletViewModel, Bullet>(productBullet);


            var updatedBullet = await _bulletService.UpdateAsync(id, bullet);

            return Ok(updatedBullet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBulletAsync(int id)
        {
            await _bulletService.DeleteAsync(id);

            return Ok("Bullet was deleted succesfully");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetItemsByFilterAsync([FromBody] BulletRequest request)
        {
            var bullets = await _bulletService.GetBulletsByFilterAsync(request);

            return Ok(bullets);
        }
    }
}
