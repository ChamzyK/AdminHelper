using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntitiesViewModels;

namespace AdminHelper.ViewModels.EntityViewModels
{
    public abstract class EntityViewModel<TEntity> : EntityViewModelBase
        where TEntity : class
    {
        private TEntity? _entity;
        private EntitiesViewModel<TEntity>? _entitiesViewModel;
        private readonly IRepository<TEntity> _repository;

        protected EntityViewModel(MainViewModel mainViewModel, IRepository<TEntity> repository)
            : base(mainViewModel)
        {
            _repository = repository;
        }

        public TEntity? Entity
        {
            get => _entity;
            set => SetField(ref _entity, value);
        }

        public EntitiesViewModel<TEntity>? EntitiesViewModel
        {
            get => _entitiesViewModel;
            set => SetField(ref _entitiesViewModel, value);
        }
        public IRepository<TEntity> Repository => _repository;

        protected override void GoBack(object? obj)
        {
            MainViewModel.ChangeContent(_entitiesViewModel);
        }
    }
}
