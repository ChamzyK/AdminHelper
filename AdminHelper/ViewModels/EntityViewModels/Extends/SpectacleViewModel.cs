using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntitiesViewModels;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class SpectacleViewModel : EntityViewModel<Spectacle>
    {
        public SpectacleViewModel(MainViewModel mainViewModel, IRepository<Spectacle> repository) 
            : base(mainViewModel, repository)
        {
        }

        protected override void Save(object? obj)
        {
            throw new System.NotImplementedException();
        }

        protected override bool CanSave(object? arg)
        {
            throw new System.NotImplementedException();
        }
    }
}
