using AdminHelper.models.entities;
using AdminHelper.Models.Repositories.Shared;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class FullnessesViewModel : EntitiesViewModel<Fullness>
    {
        public FullnessesViewModel(MainViewModel mainViewModel, IRepository<Fullness> repository) 
            : base(mainViewModel, repository)
        {
        }
        protected override bool CanCreate(object? arg) => false;
    }
}
