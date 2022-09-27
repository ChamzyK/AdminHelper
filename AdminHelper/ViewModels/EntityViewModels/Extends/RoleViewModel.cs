using AdminHelper.models.entities;
using AdminHelper.Models;
using AdminHelper.Models.Repositories.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class RoleViewModel : EntityViewModel<Role>
    {
        public RoleType? RoleType
        {
            get => Entity!.NameNavigation!;
            set
            {
                Entity!.NameNavigation = value;
                OnPropertyChanged();
            }
        }
        public Spectacle? Spectacle
        {
            get => Entity!.SpectacleIdNavigation;

            set
            {
                Entity!.SpectacleIdNavigation = value;
                OnPropertyChanged();
            }
        }
        public Actor? Actor
        {
            get => Entity!.ActorIdNavigation;
            set
            {
                Entity!.ActorIdNavigation = value;
                OnPropertyChanged();
            }
        }
        public int? Rate
        {
            get => Entity!.Rate;
            set
            {
                Entity!.Rate = value;
                OnPropertyChanged();
            }
        }

        public static IEnumerable<RoleType> RoleTypes => App.Services.GetRequiredService<IRepository<RoleType>>().Read().ToList();
        public static IEnumerable<Spectacle> Spectacles => App.Services.GetRequiredService<IRepository<Spectacle>>().Read().ToList();
        public static IEnumerable<Actor> Actors => App.Services.GetRequiredService<IRepository<Actor>>().Read().ToList();

        public RoleViewModel(MainViewModel mainViewModel, IRepository<Role> repository)
            : base(mainViewModel, repository)
        {
            Entity ??= new Role();
        }

        protected async override void Save(object? obj)
        {
            Entity!.SpectacleId = Entity?.SpectacleIdNavigation?.Id;
            Entity!.ActorId = Entity?.ActorIdNavigation?.Id;
            Repository.Update(Entity!);
            Save();

            MainViewModel.ChangeToLoading();
            await Task.Run(EntitiesViewModel!.Refresh);
            GoBack(obj);
        }
        protected override bool CanSave(object? arg) => Entity!.IsValid();
    }
}
