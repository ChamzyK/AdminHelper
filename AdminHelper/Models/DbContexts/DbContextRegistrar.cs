using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Models.DbContexts
{
    //TODO: 11
    //класс для регистрации бд в сервисах
    //для использования DI (достать в любом месте приложения)
    public static class DbContextRegistrar
    {
        public static IServiceCollection AddAdminHelperDbContext(this IServiceCollection services) =>
            services.AddDbContext<AdminHelperDbContext>();
    }
}
