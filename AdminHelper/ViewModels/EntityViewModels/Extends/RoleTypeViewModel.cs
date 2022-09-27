using AdminHelper.models.entities;
using AdminHelper.Models;
using AdminHelper.Models.Repositories.Shared;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class RoleTypeViewModel : EntityViewModel<RoleType>
    {
        public string Name
        {
            get => Entity!.Name;
            set
            {
                Entity!.Name = value;
                OnPropertyChanged();
            }
        }

        public RoleTypeViewModel(MainViewModel mainViewModel, IRepository<RoleType> repository) 
            : base(mainViewModel, repository)
        {
            Entity ??= new RoleType();
        }

        protected override bool CanSave(object? arg) => Entity!.IsValid();
    }
}
