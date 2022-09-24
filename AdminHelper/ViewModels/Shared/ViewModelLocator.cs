using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public class ViewModelLocator
    {
        public static ViewModelBase ViewModelBase => App.Services.GetRequiredService<ViewModelBase>();
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        public static SpectacleViewModel SpectacleViewModel => App.Services.GetRequiredService<SpectacleViewModel>();
    }
}
