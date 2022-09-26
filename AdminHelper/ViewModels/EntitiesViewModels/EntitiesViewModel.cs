using System.Collections.ObjectModel;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntityViewModels;
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
            _repository.SaveChanges();
            Entities?.Remove(entity);
        }
        protected override void Edit(object? obj)
        {
            var entityViewModel = App.Services.GetRequiredService<EntityViewModel<TEntity>>();
            entityViewModel.Entity = (TEntity)obj!;
            entityViewModel.EntitiesViewModel = this;
            entityViewModel.ActionText = "Изменение";
            MainViewModel.ShowLoading();
            MainViewModel.ChangeContent(entityViewModel);
        }
        protected override void Create(object? obj)
        {
            var entityViewModel = App.Services.GetRequiredService<EntityViewModel<TEntity>>();
            entityViewModel.EntitiesViewModel = this;
            entityViewModel.ActionText = "Создание";
            MainViewModel.ShowLoading();
            MainViewModel.ChangeContent(entityViewModel);
        }

        protected override bool CanDelete(object? arg) => IsEntity(arg);
        protected override bool CanEdit(object? arg) => IsEntity(arg);

        private static bool IsEntity(object? arg) => arg is TEntity;
    }
}
