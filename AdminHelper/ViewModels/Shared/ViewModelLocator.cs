using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    //TODO: 5
    //Класс нужен для получения VM из XAML кода (DI работает только в C#, а так можно и XAML'е доставать классы которые нужны)
    public class ViewModelLocator
    {
        //Идет обращение к сервисам приложения чтобы достать класс <MainViewModel>
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        //Идет обращение к сервисам приложения чтобы достать класс <LoadingViewModel>
        public static LoadingViewModel LoadingViewModel => App.Services.GetRequiredService<LoadingViewModel>();


        //Идет обращение к сервисам приложения чтобы достать класс <Spectacle>
        public static EntitiesViewModel<Spectacle> SpectaclesViewModel => App.Services.GetRequiredService<EntitiesViewModel<Spectacle>>();
        //и т.д.
        public static EntitiesViewModel<RoleType> RoleTypesViewModel => App.Services.GetRequiredService<EntitiesViewModel<RoleType>>();
        public static EntitiesViewModel<Role> RolesViewModel => App.Services.GetRequiredService<EntitiesViewModel<Role>>();
        public static EntitiesViewModel<Fullness> FullnessViewModel => App.Services.GetRequiredService<EntitiesViewModel<Fullness>>();
        public static EntitiesViewModel<Actor> ActorsViewModel => App.Services.GetRequiredService<EntitiesViewModel<Actor>>();
    }
}
