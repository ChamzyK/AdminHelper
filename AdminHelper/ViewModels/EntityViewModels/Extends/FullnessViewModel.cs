using AdminHelper.models.entities;
using AdminHelper.Models;
using AdminHelper.Models.Repositories.Shared;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class FullnessViewModel : EntityViewModel<Fullness>
    {
        public int Allowance 
        { 
            get => Entity!.Allowance;
            set
            {
                Entity!.Allowance = value;
                OnPropertyChanged();
            }
        }

        public FullnessViewModel(MainViewModel mainViewModel, IRepository<Fullness> repository)
            : base(mainViewModel, repository)
        {
            Entity ??= new Fullness();
        }

        protected override bool CanSave(object? arg) => Entity!.IsValid();
    }
}
