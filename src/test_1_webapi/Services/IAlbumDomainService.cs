using test_1_webapi_Domain.Entities;

namespace test_1_webapi_Domain.Services
{
    public interface IAlbumDomainService
    {
        void AddAlbum(string name);

        void AddAlbum(string name, User user);
    }
}
