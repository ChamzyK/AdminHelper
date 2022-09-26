using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntityViewModels;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class RoleTypesViewModel : EntitiesViewModel<RoleType>
    {
        public RoleTypesViewModel(MainViewModel mainViewModel, IRepository<RoleType> repository) 
            : base(mainViewModel, repository)
        {
        }
    }
}
