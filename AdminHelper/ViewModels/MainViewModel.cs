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


        public MainViewModel(ViewModelBase viewModelBase)
        {
            CurrentViewModel = viewModelBase;
            Title = @"Театр ""На левом берегу""";

            ChangeViewModelCommand = new RelayCommand(ChangeViewModel, CanChangeViewModel);
        }

        private bool CanChangeViewModel(object? arg) => 
            arg is ViewModelBase viewModel && 
            viewModel != CurrentViewModel;

        private void ChangeViewModel(object? obj)
        {
            var viewModel = (ViewModelBase)obj!;
            CurrentViewModel = viewModel;
        }
    }
}
