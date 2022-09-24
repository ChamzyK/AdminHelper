using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class DirectorViewModel : EntityViewModel<Director>
    {
        public DirectorViewModel(IRepository<Director> repository) : base(repository)
        {
        }
    }
}
