using AdminHelper.models.entities;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Models.Repositories
{
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddSingleton<IRepository<Actor>, EntityRepository<Actor>>()
                .AddSingleton<IRepository<Genre>, EntityRepository<Genre>>()
                .AddSingleton<IRepository<Director>, EntityRepository<Director>>()
                .AddSingleton<IRepository<RoleType>, EntityRepository<RoleType>>()
                .AddSingleton<IRepository<Spectacle>, EntityRepository<Spectacle>>();
    }
}
