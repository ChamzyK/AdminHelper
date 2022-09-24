using System.Collections.ObjectModel;
using AdminHelper.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AdminHelper.Models.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly AdminHelperDbContext _context;
        private readonly DbSet<TEntity> _set;

        public EntityRepository(AdminHelperDbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public void Create(TEntity entity) => _set.Add(entity);

        public TEntity? Read(int id) => _set.Find(id);
        public ObservableCollection<TEntity> Read()
        {
            _set.Load();
            return _set.Local.ToObservableCollection();
        }

        public TEntity Update(TEntity entity)
        {
            _context.ChangeTracker.Clear();
            return _set.Update(entity).Entity;
        }

        public bool Delete(int id) => Delete(Read(id));

        private bool Delete(TEntity? entity)
        {
            if (entity == null)
            {
                return false;
            }
            _set.Remove(entity);
            return true;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}
