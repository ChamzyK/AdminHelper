using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class ActorsViewModel : EntityViewModel<Actor>
    {
        public ActorsViewModel(IRepository<Actor> repository) : base(repository)
        {
        }
    }
}
