using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntityViewModels;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class FullnessesViewModel : EntitiesViewModel<Fullness>
    {
        public FullnessesViewModel(MainViewModel mainViewModel, IRepository<Fullness> repository) 
            : base(mainViewModel, repository)
        {
        }
    }
}
