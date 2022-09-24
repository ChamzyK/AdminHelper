using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class GenreViewModel : EntityViewModel<Genre>
    {
        public GenreViewModel(IRepository<Genre> repository) : base(repository)
        {
        }
    }
}
