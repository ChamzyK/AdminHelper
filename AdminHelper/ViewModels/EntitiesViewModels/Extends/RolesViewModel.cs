using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntityViewModels;

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
