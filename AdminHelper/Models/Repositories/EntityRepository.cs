using System.Collections.Generic;
using System.Linq;
using AdminHelper.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AdminHelper.Models.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly AdminHelperDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public EntityRepository(AdminHelperDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public void Create(TEntity entity) => _set.Add(entity);

        public virtual TEntity? Read(int id) => _set.Find(id);
        public virtual IEnumerable<TEntity> Read() => _set.AsEnumerable();

        public TEntity Update(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            return _set.Update(entity).Entity;
        }

        public void Delete(TEntity entity) => _set.Remove(entity);

        public void SaveChanges() => _context.SaveChanges();
    }
}
