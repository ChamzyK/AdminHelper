using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Windows.Input;
using AdminHelper.Infrastructure.Commands;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public abstract class EntityViewModel<TEntity> : ViewModelBase
        where TEntity : class
    {
        private ICommand? _refreshListCommand;
        private ICommand? _deleteCommand;
        private ICommand? _saveChangesCommand;

        protected EntityViewModel(IRepository<TEntity> repository)
        {
            _repository = repository;
            Refresh(null);

            RefreshListCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand(Delete);
            SaveChangesCommand = new RelayCommand(SaveChanges);
        }

        private readonly IRepository<TEntity> _repository;
        private ObservableCollection<TEntity>? _entities;

        public ObservableCollection<TEntity>? Entities
        {
            get => _entities;
            set => SetField(ref _entities, value);
        }

        public IRepository<TEntity> Repository => _repository;
        public ICommand? RefreshListCommand 
        { 
            get => _refreshListCommand; 
            set => SetField(ref _refreshListCommand, value); 
        }
        public ICommand? DeleteCommand
        {
            get => _deleteCommand;
            set => SetField(ref _deleteCommand, value);
        }
        public ICommand? SaveChangesCommand
        {
            get => _saveChangesCommand;
            set => SetField(ref _saveChangesCommand, value);
        }

        private void SaveChanges(object? obj)
        {
            _repository.SaveChanges();
            Refresh(null);
        }

        private void Delete(object? obj)
        {
            var entity = (TEntity)obj!;
            _repository.Delete(entity);
            _repository.SaveChanges();
            Entities?.Remove(entity);
        }

        private void Refresh(object? obj)
        {
            Entities?.Clear();
            Entities = _repository.Read();
        } 
    }
}
