using BLL.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace PetShopApi
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ShopContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShopContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Manufacturers.Any())
            {
                context.Manufacturers.AddRange(
                    new Manufacturer { Name = "SPASS" },
                    new Manufacturer { Name = "ДОМАШНИЙ РЕЦЕПТ" },
                    new Manufacturer { Name = "Petville" },
                    new Manufacturer { Name = "ПЕС&КОТ" },
                    new Manufacturer { Name = "КИОКО" }
                );
                context.SaveChanges();
            }

            if (!context.Suppliers.Any())
            {
                context.Suppliers.AddRange(
                    new Supplier { SupplierName = "OOO Лакомка", Phonenumber = "+79918991509" },
                    new Supplier { SupplierName = "ИП Петров", Phonenumber = "+799189912659" },
                    new Supplier { SupplierName = "ИП Калашникова", Phonenumber = "+79918568246" }
                );
                context.SaveChanges();
            }

            if (!context.ProductTypes.Any())
            {
                context.ProductTypes.AddRange(
                    new ProductType { ProductTypeName = "Корм для кошек" }, new ProductType { ProductTypeName = "Наполнитель для кошек" },
                    new ProductType { ProductTypeName = "Витамины и добавки" }, new ProductType { ProductTypeName = "Гигиена и уход" }, 
                    new ProductType { ProductTypeName = "Корм для собак" }, new ProductType { ProductTypeName = "Ветеринарная аптека" }, 
                    new ProductType { ProductTypeName = "Корм для птиц" }, new ProductType { ProductTypeName = "Корм для грызунов" }, 
                    new ProductType { ProductTypeName = "Игрушки" }
                );
                context.SaveChanges();
            }
        }
    }
}