using System.Collections.Generic;

namespace AdminHelper.Models.Repositories.Shared
{
    //TODO: 13
    //создали интерфейс доступа к данным (для DI и гибкости кода)
    //DI в принципе дарует огромную гибкость и масштабируемость, а также абстракность
    public interface IRepository<TEntity>
        where TEntity : class
    {
        //стандартный набор методов CRUD
        void Create(TEntity entity);
        TEntity? Read(int id);
        IEnumerable<TEntity> Read();
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
