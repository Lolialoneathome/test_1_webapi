using System;
using test_1_webapi_Domain.Entities;
using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_Domain.Services
{
    public class AlbumDomainService : IAlbumDomainService
    {
        protected readonly IRepository<Album> _repository;
        protected readonly IFakeIdGenerateService<Album> _idGenerateService;

        public AlbumDomainService(
            IRepository<Album>  repository)
        {
            

            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
            _idGenerateService = new FakeIdGenerateService<Album>();

        }

        public void AddAlbum(string name)
        {
            var id = _idGenerateService.GetId(_repository);

            var album = new Album(id, name);

            _repository.Add(album);
        }

        public void AddAlbum(string name, User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var id = _idGenerateService.GetId(_repository);

            var album = new Album(id, name);

            _repository.Add(album);

            user.AddAlbum(album);
        }
    }
}
