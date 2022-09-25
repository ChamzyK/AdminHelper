using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public class ViewModelLocator
    {
        public static ViewModelBase ViewModelBase => App.Services.GetRequiredService<ViewModelBase>();
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();

        public static EntityViewModel<Spectacle> SpectaclesViewModel => App.Services.GetRequiredService<EntityViewModel<Spectacle>>();
        public static EntityViewModel<RoleType> RoleTypesViewModel => App.Services.GetRequiredService<EntityViewModel<RoleType>>();
        public static EntityViewModel<Role> RolesViewModel => App.Services.GetRequiredService<EntityViewModel<Role>>();
        public static EntityViewModel<Fullness> FullnessViewModel => App.Services.GetRequiredService<EntityViewModel<Fullness>>();
        public static EntityViewModel<Actor> ActorsViewModel => App.Services.GetRequiredService<EntityViewModel<Actor>>();
    }
}
