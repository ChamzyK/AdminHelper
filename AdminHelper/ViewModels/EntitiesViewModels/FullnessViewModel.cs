using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class FullnessViewModel : EntityViewModel<Fullness>
    {
        public FullnessViewModel(IRepository<Fullness> repository) : base(repository)
        {
        }
    }
}
