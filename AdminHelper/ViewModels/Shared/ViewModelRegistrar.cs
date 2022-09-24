using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public static class ViewModelRegistrar
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services.AddSingleton<MainViewModel>()
                .AddSingleton<EntityViewModel<Spectacle>,SpectacleViewModel>()
                .AddSingleton<EntityViewModel<RoleType>, RoleTypeViewModel>()
                .AddSingleton<EntityViewModel<Genre>, GenreViewModel>()
                .AddSingleton<EntityViewModel<Director>, DirectorViewModel>()
                .AddSingleton<EntityViewModel<Actor>, ActorViewModel>()
                .AddSingleton<ViewModelBase>();
    }
}
