using BLL.Entities;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PetShopApi
{
    public class IdentitySeedData
    {
        private const string adminEmail = "admin@gmail.ru";
        private const string adminPassword = "Fantasy123!";

        private const string userEmail = "salesman@gmail.ru";
        private const string userPassword = "Fantasy123!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            ShopContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ShopContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("salesman") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("salesman"));
            }

            UserManager<User> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<User>>();

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                var user = new User { Email = userEmail, UserName = userEmail };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "salesman");
                }
            }
        }
    }
}
