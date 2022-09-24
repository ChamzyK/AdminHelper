using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class RoleTypeViewModel : EntityViewModel<RoleType>
    {
        public RoleTypeViewModel(IRepository<RoleType> repository) : base(repository)
        {
        }
    }
}
