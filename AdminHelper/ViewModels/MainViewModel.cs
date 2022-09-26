using AdminHelper.ViewModels.Shared;
using System.Threading.Tasks;

namespace AdminHelper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(LoadingViewModel loadingViewModel)
        {
            _loadingViewModel = loadingViewModel;

            CurrentViewModel = this;
            Title = @"Театр ""На левом берегу""";
        }

        private readonly LoadingViewModel _loadingViewModel;

        private string? _title;
        private ViewModelBase? _currentViewModel;

        public string? Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => SetField(ref _currentViewModel, value);
        }

        public void ShowLoading()
        {
            CurrentViewModel = _loadingViewModel;
        }
        public async void ChangeContent(object? obj)
        {
            await Task.Run(() =>
            {
                var viewModel = (ViewModelBase)obj!;
                CurrentViewModel = viewModel;
            });
        }
        public bool CanChangeContent(object? arg) => 
            arg is ViewModelBase viewModel &&
            viewModel != CurrentViewModel;
    }
}
