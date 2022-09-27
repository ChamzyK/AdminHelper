using System.Collections.Generic;
using System.Linq;
using AdminHelper.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AdminHelper.Models.Repositories.Shared
{
    //TODO: 14
    //общий класс для работы с данными, если нужны отдельные реализации то можно унаследовать функционал и переопределить методы
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
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public void Delete(TEntity entity) => _set.Remove(entity);

        public void SaveChanges() => _context.SaveChanges();
    }
}
