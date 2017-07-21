using System;
using test_1_webapi_Domain.Entities;

namespace test_1_webapi_Domain.Services
{
    public interface IUserDomainService
    {
        void AddUser(string name, string email, DateTime? date = null);

        void AddAlbum(User user, Album album);

        void DeleteAlbum(User user, Album album);

    }
}
