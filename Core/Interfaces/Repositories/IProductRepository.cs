using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);

        public Task UpdateQuantityProductsAsync(List<Product> products);
    }
}
