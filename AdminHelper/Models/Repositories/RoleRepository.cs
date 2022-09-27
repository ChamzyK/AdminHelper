using AdminHelper.models.entities;
using AdminHelper.Models.DbContexts;
using AdminHelper.Models.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AdminHelper.Models.Repositories
{
    public class RoleRepository : EntityRepository<Role>
    {
        public RoleRepository(AdminHelperDbContext context) : base(context)
        {
        }

        public override Role? Read(int id)
        {
            var role = _set.Find(id);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public override IEnumerable<Role> Read()
        {
            return _context.Roles
                .Include(role => role.SpectacleIdNavigation)
                .Include(role => role.ActorIdNavigation)
                .Include(role => role.NameNavigation);
        }
    }
}
