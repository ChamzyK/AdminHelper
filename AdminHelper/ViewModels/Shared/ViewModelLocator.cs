using AdminHelper.ViewModels.EntitiesViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.Shared
{
    public class ViewModelLocator
    {
        public static MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        public static SpectacleViewModel SpectacleViewModel => App.Services.GetRequiredService<SpectacleViewModel>();
    }
}
