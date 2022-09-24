using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public static class ViewModelRegistrar
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) =>
            services.AddSingleton<MainViewModel>()
                .AddSingleton<SpectacleViewModel>()
                .AddSingleton<ViewModelBase>();
    }
}
