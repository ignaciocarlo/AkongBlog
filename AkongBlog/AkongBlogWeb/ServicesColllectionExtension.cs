using FluentValidation;
using System.Reflection;

namespace AkongBlogWeb
{
    public static class ServicesColllectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
               config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
