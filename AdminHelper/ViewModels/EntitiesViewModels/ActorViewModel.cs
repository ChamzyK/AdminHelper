using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class ActorViewModel : EntityViewModel<Actor>
    {
        public ActorViewModel(IRepository<Actor> repository) : base(repository)
        {
        }
    }
}
