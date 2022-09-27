using AdminHelper.models.entities;
using AdminHelper.Models;
using AdminHelper.Models.Repositories.Shared;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class ActorViewModel : EntityViewModel<Actor>
    {
        public string LastName
        {
            get => Entity!.LastName;
            set 
            {
                Entity!.LastName = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => Entity!.FirstName;
            set
            {
                Entity!.FirstName = value;
                OnPropertyChanged();
            }
        }
        public string Patronymic
        {
            get => Entity!.Patronymic;
            set
            {
                Entity!.Patronymic = value;
                OnPropertyChanged();
            }
        }

        public ActorViewModel(MainViewModel mainViewModel, IRepository<Actor> repository) 
            : base(mainViewModel, repository)
        {
            Entity ??= new Actor();
        }

        protected override bool CanSave(object? arg) => Entity!.IsValid();
    }
}
