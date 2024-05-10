using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Reflection;
using VTPAdmin.DAL;
using VTPAdmin.Models;
using VTPAdmin.Repositories.Abstraction;
using VTPAdmin.Repositories.Concrete;

namespace VTPAdmin.Extensions
{
    public static class MiddlewareExtension
    {
        public static IServiceCollection AddMiddlewareExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredUniqueChars = 0;

            })
               .AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(assembly);

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
