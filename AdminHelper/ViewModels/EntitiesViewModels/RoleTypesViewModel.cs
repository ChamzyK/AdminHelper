using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class RoleTypesViewModel : EntityViewModel<RoleType>
    {
        public RoleTypesViewModel(IRepository<RoleType> repository) : base(repository)
        {
        }
    }
}
