using AdminHelper.Models.Repositories.Shared;
using AdminHelper.ViewModels.EntitiesViewModels;
using AdminHelper.ViewModels.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

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

        protected async override void Save(object? obj)
        {
            if (ActionText == "Создание")
            {
                Repository.Create(Entity!);
            }
            else
            {
                Repository.Update(Entity!);
            }
            Save();

            MainViewModel.ChangeToLoading();
            await Task.Run(EntitiesViewModel!.Refresh);
            GoBack(obj);
        }
        protected override void GoBack(object? obj)
        {
            MainViewModel.ChangeContent(_entitiesViewModel);
        }

        protected void Save()
        {
            try
            {
                _repository.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                var exceptionViewModel = App.Services.GetRequiredService<ExceptionViewModel>();
                exceptionViewModel.ExceptionText = $"Ошибка при обновлении БД: {exception.Message}";
                MainViewModel.CurrentViewModel = exceptionViewModel;
            }
        }
    }
}
