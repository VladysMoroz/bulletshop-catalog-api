using ApplicationServices.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels;
using Core.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace WebApiTest
{
    public class ColdWeaponControllerTest
    {
        private readonly IFixture _fixture;
        private readonly ColdWeaponController _sut;
        private readonly Mock<IColdWeaponService> _coldWeaponService;
        private readonly Mock<IMapper> _mapper;

        public ColdWeaponControllerTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
            _coldWeaponService = _fixture.Freeze<Mock<IColdWeaponService>>();
            _mapper = _fixture.Freeze<Mock<IMapper>>();
            _sut = _fixture.Build<ColdWeaponController>().OmitAutoProperties().Create();
        }

        [Fact]
        public async Task GetItemsByFilter_Test()
        {
            // Arrange
            var coldWeapons = new List<ColdWeapon>
            {
                new ColdWeapon()
            };

            var request = new ColdWeaponRequest();

            _coldWeaponService.Setup(cd => cd.GetColdWeaponsByFilterAsync(It.IsAny<ColdWeaponRequest>())).ReturnsAsync(coldWeapons);

            // Act
            var result = await _sut.GetItemsByFilterAsync(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);

            var value = Assert.IsType<List<ColdWeapon>>(okObjectResult.Value);

            Assert.NotNull(value);
        }

        [Fact]
        public async Task CreateWeaponAsync_Test()
        {
            // Arrange
            var coldWeaponViewModel = new ColdWeaponViewModel();
            var coldWeapon = new ColdWeapon();
            var createdWeapon = new ColdWeapon();

            _coldWeaponService.Setup(s => s.CreateAsync(It.IsAny<ColdWeapon>())).ReturnsAsync(createdWeapon);
            _mapper.Setup(m => m.Map<ColdWeaponViewModel, ColdWeapon>(coldWeaponViewModel)).Returns(coldWeapon);

            // Act
            var result = await _sut.CreateWeaponAsync(coldWeaponViewModel);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<ColdWeapon>(okObjectResult.Value);
            Assert.NotNull(value);
        }


        [Fact]
        public async Task DeleteWeaponAsync_Test()
        {
            // Arrange
            var coldWeapon = new ColdWeapon
            {
                ProductId = 1
            };

            _coldWeaponService.Setup(s => s.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            var result = await _sut.DeleteWeaponAsync(coldWeapon.ProductId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<string>(okObjectResult.Value);
            Assert.Equal("ColdWeapon was deleted successfully", value);
        }

        [Fact]
        public async Task UpdateWeaponAsync_Test()
        {
            // Arrange
            var coldWeaponViewModel = new ColdWeaponViewModel();
            var coldWeapon = new ColdWeapon();
            var updatedWeapon = new ColdWeapon();

            _coldWeaponService.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<ColdWeapon>())).ReturnsAsync(updatedWeapon);
            _mapper.Setup(m => m.Map<ColdWeaponViewModel, ColdWeapon>(coldWeaponViewModel)).Returns(coldWeapon);

            // Act
            var result = await _sut.UpdateWeaponAsync(1, coldWeaponViewModel);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<ColdWeapon>(okObjectResult.Value);
            Assert.NotNull(value);
        }


        [Fact]
public async Task GetAllColdWeaponsAsync_Test()
{
    // Arrange
    var coldWeapons = new List<ColdWeapon> { new ColdWeapon() };
    var coldWeaponViewModels = new List<ColdWeaponViewModel> { new ColdWeaponViewModel() };

    _coldWeaponService.Setup(s => s.GetAllAsync()).ReturnsAsync(coldWeapons);
    _mapper.Setup(m => m.Map<List<ColdWeapon>, List<ColdWeaponViewModel>>(coldWeapons)).Returns(coldWeaponViewModels);

    // Act
    var result = await _sut.GetAllColdWeaponsAsync();

    // Assert
    var okObjectResult = Assert.IsType<OkObjectResult>(result);
    var value = Assert.IsAssignableFrom<List<ColdWeaponViewModel>>(okObjectResult.Value); // Використовуємо IsAssignableFrom
    Assert.NotNull(value);
}
    }
}