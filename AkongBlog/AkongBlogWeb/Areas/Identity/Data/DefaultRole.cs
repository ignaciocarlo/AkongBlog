using Microsoft.AspNetCore.Identity;

namespace AkongBlogWeb.Areas.Identity.Data
{
    public static class DefaultRole
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { AkongBlogCore.Domain.Contants.Roles.Admin , AkongBlogCore.Domain.Contants.Roles.User };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
