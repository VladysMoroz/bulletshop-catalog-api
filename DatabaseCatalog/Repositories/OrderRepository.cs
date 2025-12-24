using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatabaseCatalog.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CatalogDbContext _dbContext;

        public OrderRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var dbOrder = await _dbContext.Orders.AddAsync(order);

            await _dbContext.SaveChangesAsync();

            return dbOrder.Entity;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}
