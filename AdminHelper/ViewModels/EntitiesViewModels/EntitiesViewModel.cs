using System.Collections.ObjectModel;
using AdminHelper.Models.Repositories.Shared;
using AdminHelper.ViewModels.EntityViewModels;
using AdminHelper.ViewModels.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class EntitiesViewModel<TEntity> : EntitiesViewModelBase
        where TEntity : class
    {
        public EntitiesViewModel(MainViewModel mainViewModel, IRepository<TEntity> repository)
            :base(mainViewModel)
        {
            _repository = repository;
            Refresh();
        }

        private readonly IRepository<TEntity> _repository;
        private ObservableCollection<TEntity>? _entities;

        public IRepository<TEntity> Repository => _repository;
        public ObservableCollection<TEntity>? Entities
        {
            get => _entities;
            set => SetField(ref _entities, value);
        }

        public override void Refresh()
        {
            Entities = new ObservableCollection<TEntity>(_repository.Read());
        }
        protected override void Delete(object? obj)
        {
            var entity = (TEntity)obj!;
            _repository.Delete(entity);
            Save();
            Entities?.Remove(entity);
        }

        protected void Save()
        {
            try
            {
                _repository.SaveChanges();
            }
            catch(DbUpdateException exception)
            {
                var exceptionViewModel = App.Services.GetRequiredService<ExceptionViewModel>();
                exceptionViewModel.ExceptionText = $"Ошибка при обновлении БД: {exception.Message}";
                MainViewModel.CurrentViewModel = exceptionViewModel;
            }
        }

        protected override void Edit(object? obj)
        {
            var entityViewModel = App.Services.GetRequiredService<EntityViewModel<TEntity>>();
            entityViewModel.Entity = (TEntity)obj!;
            entityViewModel.EntitiesViewModel = this;
            entityViewModel.ActionText = "Изменение";
            MainViewModel.ChangeToLoading();
            MainViewModel.ChangeContent(entityViewModel);
        }
        protected override void Create(object? obj)
        {
            var entityViewModel = App.Services.GetRequiredService<EntityViewModel<TEntity>>();
            entityViewModel.EntitiesViewModel = this;
            entityViewModel.ActionText = "Создание";
            MainViewModel.ChangeToLoading();
            MainViewModel.ChangeContent(entityViewModel);
        }

        protected override bool CanDelete(object? arg) => IsEntity(arg);
        protected override bool CanEdit(object? arg) => IsEntity(arg);
        protected override bool CanCreate(object? arg) => true;

        private static bool IsEntity(object? arg) => arg is TEntity;
    }
}
