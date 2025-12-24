using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels.Request;
using Core.ViewModels.Request.Filters;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCatalog.Repositories
{
    public class ColdWeaponRepository : IColdWeaponRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ColdWeaponRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }



            public async Task<ColdWeapon> CreateAsync(ColdWeapon coldWeapon)
        {
            var dbColdWeapon = await _dbContext.ColdWeapons.AddAsync(coldWeapon);
            await _dbContext.SaveChangesAsync();

            return dbColdWeapon.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var coldWeapon = await GetByIdAsync(id);

            if (coldWeapon != null)
            {
                _dbContext.ColdWeapons.Remove(coldWeapon);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ColdWeapon>> GetAllAsync()
        {
            var coldWeapons = await _dbContext.ColdWeapons.Include(w => w.Product).ToListAsync();

            return coldWeapons;
        }

        public async Task<ColdWeapon> GetByIdAsync(int id)
        {
            var coldWeapon = await _dbContext.ColdWeapons.Include(w => w.Product).FirstOrDefaultAsync(p => p.ProductId == id);

            return coldWeapon;
        }

        public async Task<ColdWeapon> UpdateAsync(int id, ColdWeapon model)
        {
            var existingColdWeapon = await GetByIdAsync(id);

            if (existingColdWeapon != null)
            {
                existingColdWeapon.HandleMaterialENG = model.HandleMaterialENG;
                existingColdWeapon.HandleMaterialUA = model.HandleMaterialUA;
                existingColdWeapon.BladeMaterialUA = model.BladeMaterialUA;
                existingColdWeapon.BladeMaterialENG = model.BladeMaterialENG;
                existingColdWeapon.Hardness = model.Hardness;
                existingColdWeapon.LockUA = model.LockUA;
                existingColdWeapon.LockENG = model.LockENG;

                existingColdWeapon.Product.NameUA = model.Product.NameUA;
                existingColdWeapon.Product.NameENG = model.Product.NameENG;
                existingColdWeapon.Product.ManufacturerUA = model.Product.ManufacturerUA;
                existingColdWeapon.Product.ManufacturerENG = model.Product.ManufacturerENG;
                existingColdWeapon.Product.DescriptionUA = model.Product.DescriptionUA;
                existingColdWeapon.Product.DescriptionENG = model.Product.DescriptionENG;
                existingColdWeapon.Product.Weight = model.Product.Weight;
                existingColdWeapon.Product.Photo = model.Product.Photo;
                existingColdWeapon.Product.Quantity = model.Product.Quantity;
                existingColdWeapon.Product.Price = model.Product.Price;
                existingColdWeapon.Product.OrderId = model.Product.OrderId;
            }
            await _dbContext.SaveChangesAsync();

            return existingColdWeapon;
        }

        public async Task<List<ColdWeapon>> GetItemsByFilterAsync(
            ColdWeaponFiltering filtering,
            Sorting sorting,
            Pagination pagination)
        {
            var query = _dbContext.Set<ColdWeapon>().AsQueryable();

            query = ApplyFilter(query, filtering);

            // Apply sorting
            query = DBHelper.ApplySorting(query, sorting);

            // Apply pagination
            query = DBHelper.ApplyPagination(query, pagination);

            query = query.Include("Product");

            var coldWeapons = await query.ToListAsync();
            return coldWeapons;
        }

        private IQueryable<ColdWeapon> ApplyFilter(IQueryable<ColdWeapon> query, ColdWeaponFiltering filtering)
        {
            if (filtering.HardnessMaterials != null && filtering.HardnessMaterials.Any())
            {
                query = query.Where(w => filtering.HardnessMaterials.Contains(w.Hardness));
            }

            if (filtering.Locks != null && filtering.Locks.Any())
            {
                query = query.Where(w => filtering.Locks.Contains(w.LockUA) || filtering.Locks.Contains(w.LockENG));
            }

            if (filtering.BladeMaterials != null && filtering.BladeMaterials.Any())
            {
                query = query.Where(w => filtering.BladeMaterials.Contains(w.BladeMaterialUA) || filtering.BladeMaterials.Contains(w.BladeMaterialENG));
            }

            if (filtering.HandleMaterials != null && filtering.HandleMaterials.Any())
            {
                query = query.Where(w => filtering.HandleMaterials.Contains(w.HandleMaterialUA) || filtering.HandleMaterials.Contains(w.HandleMaterialENG));
            }

            return query;
        }

    }
}
