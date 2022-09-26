using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntitiesViewModels;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class RoleTypeViewModel : EntityViewModel<RoleType>
    {
        public RoleTypeViewModel(MainViewModel mainViewModel, IRepository<RoleType> repository) 
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
