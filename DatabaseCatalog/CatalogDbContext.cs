using Core.Entities;
using DatabaseCatalog.Configurations;
using DatabaseCatalog.Seeders;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCatalog
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)  {  }
        public DbSet<Product> Products { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<ColdWeapon> ColdWeapons { get; set; }
        public DbSet<Optic> Optics { get; set; }
        public DbSet<Bullet> Bullets { get; set; }
        public DbSet<Ammunition> Ammunitions { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<SubCategory> Categories { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new SubCategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new WeaponEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ColdWeaponEntityConfiguration());

            modelBuilder.ApplyConfiguration(new OpticEntityConfiguration());

            modelBuilder.ApplyConfiguration(new BulletEntityConfiguration());

            modelBuilder.ApplyConfiguration(new AmmunitionEntityConfiguration());

            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfiguration());

            modelBuilder.ApplyConfiguration(new PreferenceEntityConfiguration());

            DbSeeder.SeedWeapon(modelBuilder);
        }     
    }
}
