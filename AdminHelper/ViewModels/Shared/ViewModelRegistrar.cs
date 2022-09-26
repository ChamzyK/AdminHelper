using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using AdminHelper.ViewModels.EntitiesViewModels.Extends;
using AdminHelper.ViewModels.EntityViewModels;
using AdminHelper.ViewModels.EntityViewModels.Extends;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public static class ViewModelRegistrar
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services
                .AddSingleton<MainViewModel>()
                .AddSingleton<LoadingViewModel>()
                .AddSingleton<ExceptionViewModel>()

                .AddSingleton<EntitiesViewModel<Spectacle>, SpectaclesViewModel>()
                .AddSingleton<EntitiesViewModel<RoleType>, RoleTypesViewModel>()
                .AddSingleton<EntitiesViewModel<Role>, RolesViewModel>()
                .AddSingleton<EntitiesViewModel<Fullness>, FullnessesViewModel>()
                .AddSingleton<EntitiesViewModel<Actor>, ActorsViewModel>()

                .AddTransient<EntityViewModel<Spectacle>, SpectacleViewModel>()
                .AddTransient<EntityViewModel<RoleType>, RoleTypeViewModel>()
                .AddTransient<EntityViewModel<Role>, RoleViewModel>()
                .AddTransient<EntityViewModel<Fullness>, FullnessViewModel>()
                .AddTransient<EntityViewModel<Actor>, ActorViewModel>();
    }
}
