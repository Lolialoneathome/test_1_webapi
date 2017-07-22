using System.Collections.Generic;
using test_1_webapi_Domain.DataModels;

namespace test_1_webapi_Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IModel
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> All();

        TEntity GetById(int id);
    }
}