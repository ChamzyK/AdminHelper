using AdminHelper.models.entities;
using AdminHelper.Models.Repositories.Shared;
using AdminHelper.ViewModels.EntityViewModels;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class SpectaclesViewModel : EntitiesViewModel<Spectacle>
    {
        public SpectaclesViewModel(MainViewModel mainViewModel, IRepository<Spectacle> repository) 
            : base(mainViewModel, repository)
        {
        }
    }
}
