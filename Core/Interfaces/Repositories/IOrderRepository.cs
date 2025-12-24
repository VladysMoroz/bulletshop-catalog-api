using Core.Entities;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> CreateOrderAsync(Order order);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
