using FluentValidation;
using MediatR;
using System.Reflection;

namespace AkongBlogWeb
{
    public static class ServicesColllectionExtension
    {
        public static void ConfigureDefaultServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
