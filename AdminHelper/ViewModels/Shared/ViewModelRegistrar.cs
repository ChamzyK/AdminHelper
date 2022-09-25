using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public static class ViewModelRegistrar
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services.AddSingleton<MainViewModel>()
                .AddSingleton<EntityViewModel<Spectacle>,SpectaclesViewModel>()
                .AddSingleton<EntityViewModel<RoleType>, RoleTypesViewModel>()
                .AddSingleton<EntityViewModel<Role>, RolesViewModel>()
                .AddSingleton<EntityViewModel<Fullness>, FullnessViewModel>()
                .AddSingleton<EntityViewModel<Actor>, ActorsViewModel>()
                .AddSingleton<ViewModelBase>();
    }
}
