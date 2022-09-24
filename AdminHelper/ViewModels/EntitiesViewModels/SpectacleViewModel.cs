﻿using AdminHelper.models.entities;
using AdminHelper.Models.Repositories;

namespace AdminHelper.ViewModels.EntitiesViewModels
{
    public class SpectacleViewModel : EntityViewModel<Spectacle>
    {
        public SpectacleViewModel(IRepository<Spectacle> repository) : base(repository)
        {
        }
    }
}
