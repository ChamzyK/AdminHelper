using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class SpectaclesViewModel : EntityViewModel<Spectacle>
    {
        public SpectaclesViewModel(IRepository<Spectacle> repository) : base(repository)
        {
        }
    }
}
