using AdminHelper.models.entities;
using AdminHelper.Models;
using AdminHelper.Models.Repositories.Shared;
using System;
using System.ComponentModel;

namespace AdminHelper.ViewModels.EntityViewModels.Extends
{
    public class SpectacleViewModel : EntityViewModel<Spectacle>
    {
        private int _hours;
        private int _minutes;

        public string Name
        {
            get => Entity!.Name;
            set
            {
                Entity!.Name = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Date
        {
            get => Entity!.Date;
            set
            {
                Entity!.Date = value;
                OnPropertyChanged();
            }
        }
        public int Hours
        {
            get => _hours;
            set => SetField(ref _hours, value);
        }
        public int Minutes
        {
            get => _minutes;
            set => SetField(ref _minutes, value);
        }

        public SpectacleViewModel(MainViewModel mainViewModel, IRepository<Spectacle> repository) 
            : base(mainViewModel, repository)
        {
            Entity ??= new Spectacle();
            PropertyChanged += EntityChanged;
        }

        private void EntityChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Entity))
            {
                Hours = ((DateTime)Entity!.Date!).Hour;
                Minutes = ((DateTime)Entity!.Date!).Minute;
            }
        }

        protected override void Save(object? obj)
        {
            var date = ((DateTime)Entity!.Date!);
            date = date.AddHours(Hours);
            date = date.AddMinutes(Minutes);
            Entity!.Date = date;
            base.Save(obj);
        }

        protected override bool CanSave(object? arg)
        {
            var isValid = Entity!.IsValid();
            var isHours = Hours < 24 && Hours >= 0;
            var isMinutes = Minutes < 60 && Minutes >= 0;
            return isValid && isHours && isMinutes;
        }
    }
}
