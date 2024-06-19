using AkongBlogCore.Domain.Identity;
using AkongBlogInfrastructure.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AkongBlogInfrastructure.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // Add Identity
        services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connectionString));
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityContext>();

        return services;
    }
}
