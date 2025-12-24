using AutoFixture.AutoMoq;
using AutoFixture;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace WebApiTest
{
    public class OrderControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly OrderController _orderController;

        public OrderControllerTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                              .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _orderServiceMock = _fixture.Freeze<Mock<IOrderService>>();
            _mapperMock = _fixture.Freeze<Mock<IMapper>>();
            _orderController = new OrderController(_orderServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateOrder_ValidOrder_ReturnsOkResult()
        {
            // Arrange
            var orderViewModel = _fixture.Create<OrderViewModel>();
            var order = _fixture.Create<Order>();
            var createdOrder = _fixture.Build<Order>()
                                       .With(o => o.Id, order.Id)
                                       .With(o => o.DeliveryAdress, order.DeliveryAdress)
                                       .With(o => o.StatusENG, order.StatusENG)
                                       .With(o => o.CreationTime, DateTime.UtcNow) 
                                       .Create();

            _mapperMock.Setup(m => m.Map<Order>(orderViewModel)).Returns(order);
            _orderServiceMock.Setup(s => s.CreateOrderAsync(order)).ReturnsAsync(createdOrder);

            // Act
            var result = await _orderController.CreateOrder(orderViewModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedOrder = Assert.IsType<Order>(okResult.Value);

            Assert.Equal(createdOrder.Id, returnedOrder.Id);
            Assert.Equal(createdOrder.DeliveryAdress, returnedOrder.DeliveryAdress);
            Assert.Equal(createdOrder.StatusENG, returnedOrder.StatusENG);
        }

        [Fact]
        public async Task CreateOrder_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            _orderController.ModelState.AddModelError("Error", "Invalid model");

            // Act
            var result = await _orderController.CreateOrder(new OrderViewModel());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var modelState = Assert.IsType<SerializableError>(badRequestResult.Value);
            Assert.True(modelState.ContainsKey("Error"));
        }
    }
}
