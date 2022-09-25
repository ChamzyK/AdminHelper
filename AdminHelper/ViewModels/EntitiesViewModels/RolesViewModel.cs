using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class RolesViewModel : EntityViewModel<Role>
    {
        public RolesViewModel(IRepository<Role> repository) : base(repository)
        {
        }
    }
}
