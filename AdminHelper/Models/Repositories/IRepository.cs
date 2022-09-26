using System.Collections.Generic;

namespace AdminHelper.Models.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        void Create(TEntity entity);
        TEntity? Read(int id);
        IEnumerable<TEntity> Read();
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
