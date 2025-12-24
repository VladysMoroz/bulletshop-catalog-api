using AutoMapper;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.ViewModels;
using Core.ViewModels.Request.Filters;
using Core.ViewModels.Request;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCatalog.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly CatalogDbContext _dbContext;

        public WeaponRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Weapon> CreateAsync(Weapon weapon)
        {
            var dbWeapon = await _dbContext.Weapons.AddAsync(weapon);
            await _dbContext.SaveChangesAsync();

            return dbWeapon.Entity;
        }

        public async Task<List<Weapon>> GetAllAsync()
        {
            var weapons = await _dbContext.Weapons.Include(w => w.Product).ToListAsync();

            return weapons;
        }

        public async Task<Weapon> GetByIdAsync(int id)
        {
            var weapon = await _dbContext.Weapons.Include(w => w.Product).FirstOrDefaultAsync(p => p.ProductId == id);

            return weapon;
        }

        public async Task<Weapon> UpdateAsync(int id, 
            Weapon weapon)
        {
            var existingWeapon = await GetByIdAsync(id);

            if (existingWeapon != null)
            {
                existingWeapon.Caliber = weapon.Caliber;
                existingWeapon.MagazineCapacity = weapon.MagazineCapacity;
                existingWeapon.GeneralLength = weapon.GeneralLength;
                existingWeapon.BarrelLength = weapon.BarrelLength;
                existingWeapon.SightingDevicesUA = weapon.SightingDevicesUA;
                existingWeapon.SightingDevicesENG = weapon.SightingDevicesENG;
                existingWeapon.GunStockAndButtUA = weapon.GunStockAndButtUA;
                existingWeapon.GunStockAndButtENG = weapon.GunStockAndButtENG;
                existingWeapon.InitialVelocity = weapon.InitialVelocity;
                existingWeapon.BarrelTwist = weapon.BarrelTwist;
                existingWeapon.TypeUA = weapon.TypeUA;
                existingWeapon.TypeENG = weapon.TypeENG;

                existingWeapon.Product.NameUA = weapon.Product.NameUA;
                existingWeapon.Product.NameENG = weapon.Product.NameENG;
                existingWeapon.Product.ManufacturerUA = weapon.Product.ManufacturerUA;
                existingWeapon.Product.ManufacturerENG = weapon.Product.ManufacturerENG;
                existingWeapon.Product.DescriptionUA = weapon.Product.DescriptionUA;
                existingWeapon.Product.DescriptionENG = weapon.Product.DescriptionENG;
                existingWeapon.Product.Weight = weapon.Product.Weight;
                existingWeapon.Product.Photo = weapon.Product.Photo;
                existingWeapon.Product.Quantity = weapon.Product.Quantity;
                existingWeapon.Product.Price = weapon.Product.Price;
                existingWeapon.Product.OrderId = weapon.Product.OrderId;
                existingWeapon.Product.SubCategoryId = weapon.Product.SubCategoryId;
            }
            await _dbContext.SaveChangesAsync();
           
            return existingWeapon;
        }

        public async Task DeleteAsync(int id)
        {
            var weapon = await GetByIdAsync(id);

            if (weapon != null)
            {
                _dbContext.Weapons.Remove(weapon);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<List<Weapon>> GetItemsByFilterAsync(
            WeaponFiltering filtering,
            Sorting sorting,
            Pagination pagination)
        {
            var query = _dbContext.Set<Weapon>().AsQueryable();

            query = ApplyFilter(query, filtering);

            // Apply sorting
            query = DBHelper.ApplySorting(query, sorting);

            // Apply pagination
            query = DBHelper.ApplyPagination(query, pagination);

            query = query.Include("Product");

            var coldWeapons = await query.ToListAsync();
            return coldWeapons;
        }

        private IQueryable<Weapon> ApplyFilter(IQueryable<Weapon> query, WeaponFiltering filtering)
        {
            if (filtering.InitialVelocities != null && filtering.InitialVelocities.Any())
            {
                query = query.Where(w => filtering.InitialVelocities.Contains(w.InitialVelocity));
            }

            if (filtering.BarrelTwists != null && filtering.BarrelTwists.Any())
            {
                query = query.Where(w => filtering.BarrelTwists.Contains(w.BarrelTwist));
            }

            if (filtering.SightingDevices != null && filtering.SightingDevices.Any())
            {
                query = query.Where(w => filtering.SightingDevices.Contains(w.SightingDevicesUA) || filtering.SightingDevices.Contains(w.SightingDevicesENG));
            }

            if (filtering.Calibers != null && filtering.Calibers.Any())
            {
                query = query.Where(w => filtering.Calibers.Contains(w.Caliber));
            }

            if (filtering.GunStockAndButts != null && filtering.GunStockAndButts.Any())
            {
                query = query.Where(w => filtering.GunStockAndButts.Contains(w.GunStockAndButtUA) || filtering.GunStockAndButts.Contains(w.GunStockAndButtENG));
            }

            if (filtering.MagazineCapacities != null && filtering.MagazineCapacities.Any())
            {
                query = query.Where(w => filtering.MagazineCapacities.Contains(w.MagazineCapacity));
            }

            return query;
        }
    }
}
