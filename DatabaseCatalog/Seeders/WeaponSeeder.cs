using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCatalog.Seeders
{
    public static class DbSeeder
{
    public static void SeedWeapon(ModelBuilder modelBuilder)
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                NameUA = "Автомат Калашникова",
                NameENG = "Kalashnikov Rifle",
                ManufacturerUA = "Іжевський механічний завод",
                ManufacturerENG = "Izhmash",
                DescriptionUA = "Найпопулярніша у світі штурмова гвинтівка.",
                DescriptionENG = "The most popular assault rifle in the world.",
                Weight = 3.47m,
                Photo = "kalashnikov.jpg",
                Quantity = 100,
                Price = 300m,
                SubCategoryId = 1,
                CreationTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 2,
                NameUA = "Пістолет Макарова",
                NameENG = "Makarov Pistol",
                ManufacturerUA = "Іжевський механічний завод",
                ManufacturerENG = "Izhmash",
                DescriptionUA = "Радянський самозарядний пістолет.",
                DescriptionENG = "Soviet semi-automatic pistol.",
                Weight = 0.73m,
                Photo = "makarov.jpg",
                Quantity = 200,
                Price = 150m,
                SubCategoryId = 2,
                CreationTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 3,
                NameUA = "Снайперська гвинтівка Драгунова",
                NameENG = "Dragunov Sniper Rifle",
                ManufacturerUA = "Іжевський механічний завод",
                ManufacturerENG = "Izhmash",
                DescriptionUA = "Радянська напівавтоматична снайперська гвинтівка.",
                DescriptionENG = "Soviet semi-automatic sniper rifle.",
                Weight = 4.3m,
                Photo = "dragunov.jpg",
                Quantity = 50,
                Price = 1000m,
                SubCategoryId = 3,
                CreationTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 4,
                NameUA = "Мосінська гвинтівка",
                NameENG = "Mosin-Nagant Rifle",
                ManufacturerUA = "Тульський збройний завод",
                ManufacturerENG = "Tula Arms Plant",
                DescriptionUA = "Російська гвинтівка кінця 19-го століття.",
                DescriptionENG = "Russian rifle from the late 19th century.",
                Weight = 4.0m,
                Photo = "mosin.jpg",
                Quantity = 75,
                Price = 500m,
                SubCategoryId = 4,
                CreationTime = DateTime.UtcNow
            },
            new Product
            {
                Id = 5,
                NameUA = "Магнум Револьвер",
                NameENG = "Magnum Revolver",
                ManufacturerUA = "Smith & Wesson",
                ManufacturerENG = "Smith & Wesson",
                DescriptionUA = "Американський револьвер великого калібру.",
                DescriptionENG = "American large-caliber revolver.",
                Weight = 1.25m,
                Photo = "magnum.jpg",
                Quantity = 80,
                Price = 600m,
                SubCategoryId = 5,
                CreationTime = DateTime.UtcNow
            }
        };

        var weapons = new List<Weapon>
        {
            new Weapon
            {
                Id = 1,
                ProductId = 1,
                Caliber = "7.62mm",
                MagazineCapacity = 30,
                GeneralLength = 870,
                BarrelLength = 415,
                SightingDevicesUA = "Механічний приціл",
                SightingDevicesENG = "Iron sights",
                GunStockAndButtUA = "Складний приклад",
                GunStockAndButtENG = "Folding stock",
                InitialVelocity = 715,
                BarrelTwist = "1:9.45",
                TypeUA = "Автомат",
                TypeENG = "Assault Rifle"
            },
            new Weapon
            {
                Id = 2,
                ProductId = 2,
                Caliber = "9mm",
                MagazineCapacity = 8,
                GeneralLength = 161,
                BarrelLength = 93,
                SightingDevicesUA = "Механічний приціл",
                SightingDevicesENG = "Iron sights",
                GunStockAndButtUA = "Фіксований приклад",
                GunStockAndButtENG = "Fixed stock",
                InitialVelocity = 315,
                BarrelTwist = "1:10",
                TypeUA = "Пістолет",
                TypeENG = "Pistol"
            },
            new Weapon
            {
                Id = 3,
                ProductId = 3,
                Caliber = "7.62mm",
                MagazineCapacity = 10,
                GeneralLength = 1225,
                BarrelLength = 620,
                SightingDevicesUA = "Оптичний приціл",
                SightingDevicesENG = "Optical sight",
                GunStockAndButtUA = "Фіксований приклад",
                GunStockAndButtENG = "Fixed stock",
                InitialVelocity = 830,
                BarrelTwist = "1:9.5",
                TypeUA = "Снайперська гвинтівка",
                TypeENG = "Sniper Rifle"
            },
            new Weapon
            {
                Id = 4,
                ProductId = 4,
                Caliber = "7.62mm",
                MagazineCapacity = 5,
                GeneralLength = 1230,
                BarrelLength = 730,
                SightingDevicesUA = "Механічний приціл",
                SightingDevicesENG = "Iron sights",
                GunStockAndButtUA = "Фіксований приклад",
                GunStockAndButtENG = "Fixed stock",
                InitialVelocity = 865,
                BarrelTwist = "1:9.5",
                TypeUA = "Гвинтівка",
                TypeENG = "Rifle"
            },
            new Weapon
            {
                Id = 5,
                ProductId = 5,
                Caliber = "0.44 Magnum",
                MagazineCapacity = 6,
                GeneralLength = 308,
                BarrelLength = 101,
                SightingDevicesUA = "Механічний приціл",
                SightingDevicesENG = "Iron sights",
                GunStockAndButtUA = "Фіксований приклад",
                GunStockAndButtENG = "Fixed stock",
                InitialVelocity = 450,
                BarrelTwist = "1:18.75",
                TypeUA = "Револьвер",
                TypeENG = "Revolver"
            }
        };

        var category = new Category
        {
            Id = 1,
            NameUA = "Вогнепальна зброя",
            NameENG = "Firearms"
        };

        var subCategories = new List<SubCategory>
        {
            new SubCategory
            {
                Id = 1,
                NameUA = "Автомати",
                NameENG = "Assault Rifles",
                CategoryId = category.Id
            },
            new SubCategory
            {
                Id = 2,
                NameUA = "Пістолети",
                NameENG = "Pistols",
                CategoryId = category.Id
            },
            new SubCategory
            {
                Id = 3,
                NameUA = "Снайперські гвинтівки",
                NameENG = "Sniper Rifles",
                CategoryId = category.Id
            },
            new SubCategory
            {
                Id = 4,
                NameUA = "Гвинтівки",
                NameENG = "Rifles",
                CategoryId = category.Id
            },
            new SubCategory
            {
                Id = 5,
                NameUA = "Револьвери",
                NameENG = "Revolvers",
                CategoryId = category.Id
            }
        };

        modelBuilder.Entity<Category>().HasData(category);
        modelBuilder.Entity<SubCategory>().HasData(subCategories);
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Weapon>().HasData(weapons);
    }
}
}



public static class DbSeeder
{
    public static void SeedWeapon(ModelBuilder modelBuilder)
    {
        var products = new List<Product>
        {
             new Product
            {
                Id = 1,
                NameUA = "Автомат Калашникова",
                NameENG = "Kalashnikov Rifle",
                ManufacturerUA = "Іжевський механічний завод",
                ManufacturerENG = "Izhmash",
                DescriptionUA = "Найпопулярніша у світі штурмова гвинтівка.",
                DescriptionENG = "The most popular assault rifle in the world.",
                Weight = 3.47m,
                Photo = "kalashnikov.jpg",
                Quantity = 100,
                Price = 300m,
                SubCategoryId = 1,
                CreationTime = DateTime.UtcNow
            },
            // Інші продукти
        };

        var weapons = new List<Weapon>
        {
            new Weapon
            {
                Id = 1,
                ProductId = 1,
                Caliber = "7.62mm",
                MagazineCapacity = 30,
                GeneralLength = 870,
                BarrelLength = 415,
                SightingDevicesUA = "Механічний приціл",
                SightingDevicesENG = "Iron sights",
                GunStockAndButtUA = "Складний приклад",
                GunStockAndButtENG = "Folding stock",
                InitialVelocity = 715,
                BarrelTwist = "1:9.45",
                TypeUA = "Автомат",
                TypeENG = "Assault Rifle"
            },
            // Інші зброї
        };

        var category = new Category
        {
            Id = 1,
            NameUA = "Вогнепальна зброя",
            NameENG = "Firearms"
        };

        var subCategories = new List<SubCategory>
        {
            new SubCategory
            {
                Id = 1,
                NameUA = "Автомати",
                NameENG = "Assault Rifles",
                CategoryId = category.Id
            },
            // Інші підкатегорії
        };

        modelBuilder.Entity<Category>().HasData(category);
        modelBuilder.Entity<SubCategory>().HasData(subCategories);

        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Weapon>().HasData(weapons);
    }
}
