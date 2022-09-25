using System.Collections.ObjectModel;

namespace AdminHelper.Models.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        void Create(TEntity entity);
        TEntity? Read(int id);
        ObservableCollection<TEntity> Read();
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
