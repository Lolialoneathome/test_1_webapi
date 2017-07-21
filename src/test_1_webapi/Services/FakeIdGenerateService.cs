using System;
using System.Linq;
using test_1_webapi_Domain.Entities;
using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_Domain.Services
{
    public class FakeIdGenerateService<TEntity> : IFakeIdGenerateService<TEntity>
        where TEntity : IEntity
    {
        /*Такой сервис вообще не подойдет в реальных условиях 
        Потому что не будет работать при многопользовательском доступе
        Генерацию id-шников лучше делать в БД
        Этот севис написан только для тестирования */
        public int GetId(IRepository<TEntity> repository)
        {
            if (repository.All().Count() > 0)
            {
                var maxId = repository.All().Max(x => x.Id);
                return maxId+1;
            }
                

            return 0;
        }
    }
}
