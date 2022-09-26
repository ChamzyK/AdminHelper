using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntitiesViewModels;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class FullnessViewModel : EntityViewModel<Fullness>
    {
        public FullnessViewModel(MainViewModel mainViewModel, IRepository<Fullness> repository) 
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
