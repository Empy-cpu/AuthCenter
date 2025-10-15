using AuthServer.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthCenter.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create test role if missing
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            // Create test user if missing
            var testUser = await userManager.FindByNameAsync("testuser");
            if (testUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "testuser",
                    Email = "testuser@example.com",
                    TenantId = "tenant1"
                };

                var result = await userManager.CreateAsync(user, "Pass@123");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
