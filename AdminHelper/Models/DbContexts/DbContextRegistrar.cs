using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Models.DbContexts
{
    public static class DbContextRegistrar
    {
        public static IServiceCollection AddAdminHelperDbContext(this IServiceCollection services) =>
            services.AddDbContext<AdminHelperDbContext>();
    }
}
