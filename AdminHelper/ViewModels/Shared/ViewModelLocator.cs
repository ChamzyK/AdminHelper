using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        public static LoadingViewModel LoadingViewModel => App.Services.GetRequiredService<LoadingViewModel>();

        public static EntitiesViewModel<Spectacle> SpectaclesViewModel => App.Services.GetRequiredService<EntitiesViewModel<Spectacle>>();
        public static EntitiesViewModel<RoleType> RoleTypesViewModel => App.Services.GetRequiredService<EntitiesViewModel<RoleType>>();
        public static EntitiesViewModel<Role> RolesViewModel => App.Services.GetRequiredService<EntitiesViewModel<Role>>();
        public static EntitiesViewModel<Fullness> FullnessViewModel => App.Services.GetRequiredService<EntitiesViewModel<Fullness>>();
        public static EntitiesViewModel<Actor> ActorsViewModel => App.Services.GetRequiredService<EntitiesViewModel<Actor>>();
    }
}
