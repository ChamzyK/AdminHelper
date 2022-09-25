using AdminHelper.models.entities;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Models.Repositories
{
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddSingleton<IRepository<Actor>, EntityRepository<Actor>>()
                .AddSingleton<IRepository<Role>, EntityRepository<Role>>()
                .AddSingleton<IRepository<Fullness>, EntityRepository<Fullness>>()
                .AddSingleton<IRepository<RoleType>, EntityRepository<RoleType>>()
                .AddSingleton<IRepository<Spectacle>, EntityRepository<Spectacle>>();
    }
}
