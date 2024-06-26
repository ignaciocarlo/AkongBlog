using AkongBlogCore.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace AkongBlogWeb.Areas.Identity.Data
{
    public static class DefaultUser
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string email = "system@admin";
            string password = "Test123!@#";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, AkongBlogCore.Domain.Contants.Roles.Admin);
            }
        }
    }
}
