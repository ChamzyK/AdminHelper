using AdminHelper.Infrastructure.Commands;
using AdminHelper.ViewModels.Shared;
using System.Windows.Input;

namespace AdminHelper.ViewModels.EntityViewModels
{
    public abstract class EntityViewModelBase : ViewModelBase
    {
        protected EntityViewModelBase(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;

            GoBackCommand = new RelayCommand(GoBack);
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private MainViewModel _mainViewModel = null!;
        private string _actionText = string.Empty;
        private ICommand? _saveCommand;
        private ICommand? _goBackCommand;

        public MainViewModel MainViewModel
        {
            get => _mainViewModel;
            set => SetField(ref _mainViewModel, value);
        }
        public string ActionText
        {
            get => _actionText;
            set => SetField(ref _actionText, value);
        }
        public ICommand? SaveCommand
        {
            get => _saveCommand;
            set => SetField(ref _saveCommand, value);
        }
        public ICommand? GoBackCommand
        {
            get => _goBackCommand;
            set => SetField(ref _goBackCommand, value);
        }

        protected abstract void GoBack(object? obj);
        protected abstract void Save(object? obj);

        protected abstract bool CanSave(object? arg);
    }
}
