using AdminHelper.Infrastructure.Commands;
using AdminHelper.ViewModels.Shared;
using System.Windows.Input;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public abstract class EntitiesViewModelBase : ViewModelBase
    {
        protected EntitiesViewModelBase(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            RefreshCommand = new RelayCommand(obj => Refresh());
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            EditCommand = new RelayCommand(Edit, CanEdit);
            CreateCommand = new RelayCommand(Create, CanCreate);
        }

        private readonly MainViewModel _mainViewModel;

        private ICommand? _refreshCommand;
        private ICommand? _deleteCommand;
        private ICommand? _editCommand;
        private ICommand? _createCommand;

        public MainViewModel MainViewModel => _mainViewModel;

        public ICommand? RefreshCommand
        {
            get => _refreshCommand;
            set => SetField(ref _refreshCommand, value);
        }
        public ICommand? DeleteCommand
        {
            get => _deleteCommand;
            set => SetField(ref _deleteCommand, value);
        }
        public ICommand? EditCommand
        {
            get => _editCommand;
            set => SetField(ref _editCommand, value);
        }
        public ICommand? CreateCommand
        {
            get => _createCommand;
            set => SetField(ref _createCommand, value);
        }

        public abstract void Refresh();
        protected abstract void Delete(object? obj);
        protected abstract void Edit(object? obj);
        protected abstract void Create(object? obj);

        protected abstract bool CanDelete(object? arg);
        protected abstract bool CanEdit(object? arg);
        protected abstract bool CanCreate(object? arg);
    }
}
