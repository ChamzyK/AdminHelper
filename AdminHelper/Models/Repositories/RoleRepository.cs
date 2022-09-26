using AdminHelper.models.entities;
using AdminHelper.Models.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace AdminHelper.Models.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly AdminHelperDbContext _context;
        private readonly DbSet<Role> _set;

        public RoleRepository(AdminHelperDbContext context)
        {
            _context = context;
            _set = context.Set<Role>();
        }

        public void Create(Role entity) => _set.Add(entity);

        public void Delete(Role entity) => _set.Remove(entity);

        public Role? Read(int id)
        {
            var role = _set.Find(id);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public ObservableCollection<Role> Read()
        {
            var roles = _context.Roles
                .Include(role => role.SpectacleIdNavigation)
                .Include(role => role.ActorIdNavigation)
                .Include(role => role.NameNavigation);
            return new ObservableCollection<Role>(roles);
        }

        public void SaveChanges() => _context.SaveChanges();

        public Role Update(Role entity) => _set.Update(entity).Entity;
    }
}
