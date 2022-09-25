using System.Threading.Tasks;
using System.Windows.Input;
using AdminHelper.Infrastructure.Commands;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string? _title;
        private ViewModelBase? _currentViewModel;
        private ICommand? _changeViewModelCommand;
        private readonly ViewModelBase _loadingViewModel;

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
        public ICommand ChangeViewModelCommand
        {
            get => _changeViewModelCommand!;
            set => SetField(ref _changeViewModelCommand, value);
        }

        public MainViewModel(LoadingViewModel loadingViewModel)
        {
            _loadingViewModel = loadingViewModel;
            CurrentViewModel = this;
            Title = @"Театр ""На левом берегу""";

            ChangeViewModelCommand = new RelayCommand(ChangeViewModel, CanChangeViewModel);
        }

        private bool CanChangeViewModel(object? arg) => 
            arg is ViewModelBase viewModel && 
            viewModel != CurrentViewModel;
        private async void ChangeViewModel(object? obj)
        {
            CurrentViewModel = _loadingViewModel;
            await Task.Run(() => 
            {
                var viewModel = (ViewModelBase)obj!;
                CurrentViewModel = viewModel; 
            });
        }
    }
}
