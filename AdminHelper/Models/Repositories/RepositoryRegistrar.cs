using AdminHelper.models.entities;
using AdminHelper.Models.Repositories.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Models.Repositories
{
    //TODO: 15 
    //регистрация классов-репозиториев для DI
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddSingleton<IRepository<Actor>, ActorRepository>()
                .AddSingleton<IRepository<Role>, RoleRepository>()
                .AddSingleton<IRepository<Fullness>, EntityRepository<Fullness>>()
                .AddSingleton<IRepository<RoleType>, RoleTypeRepository>()
                .AddSingleton<IRepository<Spectacle>, SpectacleRepository>();
    }
}
