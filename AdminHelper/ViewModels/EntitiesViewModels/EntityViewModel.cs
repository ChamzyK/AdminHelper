using System.Collections.ObjectModel;
using System.Windows.Input;
using AdminHelper.Infrastructure.Commands;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.Interfaces;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public abstract class EntityViewModel<TEntity> : ViewModelBase, IRefreshable
        where TEntity : class
    {
        protected EntityViewModel(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        private readonly IRepository<TEntity> _repository;
        private ObservableCollection<TEntity>? _entities;

        public ObservableCollection<TEntity>? Entities
        {
            get => _entities;
            set => SetField(ref _entities, value);
        }

        public ICommand RefreshListCommand => new RelayCommand(obj => Refresh());
        public ICommand CreateCommand => new RelayCommand(Create, CanCreate);
        public ICommand UpdateCommand => new RelayCommand(Update, CanUpdate);
        public ICommand DeleteCommand => new RelayCommand(Delete, CanDelete);
        public ICommand SaveChangesCommand => new RelayCommand(SaveChanges);

        private void SaveChanges(object? obj)
        {
            _repository.SaveChanges();
        }

        private void Create(object? obj)
        {
            var entity = obj as TEntity;
            _repository.Create(entity!);
            _repository.SaveChanges();
        }
        private static bool CanCreate(object? arg) => arg is TEntity;

        private void Delete(object? obj)
        {
            var id = (int)obj!;
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        private static bool CanDelete(object? arg) => arg is int;

        private void Update(object? obj)
        {
            var entity = obj as TEntity;
            _repository.Update(entity!);
            _repository.SaveChanges();
        }
        private static bool CanUpdate(object? arg) => arg is TEntity;

        public void Refresh() => Entities = _repository.Read();
    }
}
