using System.Collections.Generic;
using test_1_webapi_Domain.Entities;

namespace test_1_webapi_Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> All();

        TEntity GetById(int id);
    }
}