using AdminHelper.models.entities;
using AdminHelper.Models.DbContexts;
using AdminHelper.Models.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AdminHelper.Models.Repositories
{
    public class SpectacleRepository : EntityRepository<Spectacle>
    {
        public SpectacleRepository(AdminHelperDbContext context) : base(context)
        {
        }

        public override IEnumerable<Spectacle> Read() => _context.Spectacles.Include(spectacle => spectacle.Roles);
    }
}
