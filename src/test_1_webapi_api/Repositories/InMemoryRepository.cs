using System;
using System.Collections.Generic;
using System.Linq;
using test_1_webapi_Domain.Entities;

using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_api.Repositories
{
    //Этот класс не нужен
    //Он нужен был, пока у меня интернета не было :)
    public class InMemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly List<TEntity> _list = new List<TEntity>();



        public void Add(TEntity entity)
        {
            _list.Add(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return _list;
        }

        public TEntity GetById(int id)
        {
            return _list.SingleOrDefault(x => x.Id == id);
        }
    }
}
