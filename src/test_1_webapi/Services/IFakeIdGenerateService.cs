using test_1_webapi_Domain.Entities;
using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_Domain.Services
{
    public interface IFakeIdGenerateService<TEntity>
        where TEntity : IEntity

    {
        int GetId(IRepository<TEntity> repository);
    }
}
