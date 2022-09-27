using AdminHelper.models.entities;
using AdminHelper.ViewModels.EntitiesViewModels;
using AdminHelper.ViewModels.EntitiesViewModels.Extends;
using AdminHelper.ViewModels.EntityViewModels;
using AdminHelper.ViewModels.EntityViewModels.Extends;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    //TODO: 6
    //Класс для реализации метода расширения регистрации сервисов
    public static class ViewModelRegistrar
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services
                .AddSingleton<MainViewModel>() //добавляем класс <MainViewModel>, который в будущем можно достать в любом классе через конструктор
                .AddSingleton<LoadingViewModel>()
                .AddSingleton<ExceptionViewModel>()

                .AddSingleton<EntitiesViewModel<Spectacle>, SpectaclesViewModel>() //преимущество DI, здесь указывается что при объявлении в конструкторе
                                                                                   //любого класса входного параметра EntitiesViewModel<Spectacle>,
                                                                                   //вместо него подставляется класс SpectacleViewModel
                .AddSingleton<EntitiesViewModel<RoleType>, RoleTypesViewModel>()//и т.д.
                .AddSingleton<EntitiesViewModel<Role>, RolesViewModel>()
                .AddSingleton<EntitiesViewModel<Fullness>, FullnessesViewModel>()
                .AddSingleton<EntitiesViewModel<Actor>, ActorsViewModel>()

                .AddTransient<EntityViewModel<Spectacle>, SpectacleViewModel>()
                .AddTransient<EntityViewModel<RoleType>, RoleTypeViewModel>()
                .AddTransient<EntityViewModel<Role>, RoleViewModel>()
                .AddTransient<EntityViewModel<Fullness>, FullnessViewModel>()
                .AddTransient<EntityViewModel<Actor>, ActorViewModel>();

        //singleton - везде один и тот же объект
        //transient - везде разные объекты
    }
}
