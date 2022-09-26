using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.EntityViewModels;

namespace AdminHelper.ViewModels.EntitiesViewModels.Extends
{
    public class ActorsViewModel : EntitiesViewModel<Actor>
    {
        public ActorsViewModel(MainViewModel mainViewModel, IRepository<Actor> repository) 
            : base(mainViewModel, repository)
        {
        }
    }
}
