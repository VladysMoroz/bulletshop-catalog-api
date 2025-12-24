using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        //private readonly object lockObject = new object();

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        //public async Task<Order> CreateOrderAsync(Order order)
        //{


        //    var pd = order.OrderDetails;

        //    var pIds = pd.Select(x => x.ProductId).ToList();

        //    lock (lockObject)
        //    {
        //        var products = _productRepository.GetProductsByIdsAsync(pIds).Result;

        //        foreach (var detail in pd)
        //        {
        //            var product = products.FirstOrDefault(x => x.Id == detail.ProductId);

        //            if (product.Quantity < detail.Quantity)
        //            {
        //                throw new Exception($"Not enough products = {product.NameENG}");
        //            }
        //            else
        //            {
        //                detail.Price = product.Price;

        //                product.Quantity -= detail.Quantity;
        //            }
        //        }

        //        _productRepository.UpdateQuantityProductsAsync(products);
        //    }

        //    var createdOrder = await _orderRepository.CreateOrderAsync(order);

        //    return order;
        //}

        public async Task<Order> CreateOrderAsync(Order order)
        {
            using var transaction = await _orderRepository.BeginTransactionAsync();

            try
            {
                var pd = order.OrderDetails;
                var pIds = pd.Select(x => x.ProductId).ToList();
                var products = await _productRepository.GetProductsByIdsAsync(pIds);

                foreach (var detail in pd)
                {
                    var product = products.FirstOrDefault(x => x.Id == detail.ProductId);
                    if (product == null)
                    {
                        throw new Exception($"Product with ID {detail.ProductId} not found.");
                    }

                    if (product.Quantity < detail.Quantity)
                    {
                        throw new Exception($"Not enough products = {product.NameENG}");
                    }

                    detail.Price = product.Price;
                    product.Quantity -= detail.Quantity;
                }

                await _productRepository.UpdateQuantityProductsAsync(products);
                var createdOrder = await _orderRepository.CreateOrderAsync(order);

                await transaction.CommitAsync();

                return createdOrder;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while creating the order.", ex);
            }
        }
    }
}
