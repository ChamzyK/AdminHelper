using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public class ViewModelLocator
    {
        public static ViewModelBase ViewModelBase => App.Services.GetRequiredService<ViewModelBase>();
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();

        public static EntityViewModel<Spectacle> SpectacleViewModel => App.Services.GetRequiredService<EntityViewModel<Spectacle>>();
        public static EntityViewModel<RoleType> RoleTypeViewModel => App.Services.GetRequiredService<EntityViewModel<RoleType>>();
        public static EntityViewModel<Genre> GenreViewModel => App.Services.GetRequiredService<EntityViewModel<Genre>>();
        public static EntityViewModel<Director> DirectorViewModel => App.Services.GetRequiredService<EntityViewModel<Director>>();
        public static EntityViewModel<Actor> ActorViewModel => App.Services.GetRequiredService<EntityViewModel<Actor>>();
    }
}
