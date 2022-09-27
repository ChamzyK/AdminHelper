using AdminHelper.models.entities;
using AdminHelper.Models.Repositories.Shared;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class RolesViewModel : EntitiesViewModel<Role>
    {
        public RolesViewModel(MainViewModel mainViewModel, IRepository<Role> repository) 
            : base(mainViewModel, repository)
        {
        }
    }
}
