using System;
using System.Linq;
using test_1_webapi_Domain.Entities;
using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        protected readonly IRepository<User> _userRepository;
        protected readonly IRepository<Album> _albumRepository;
        protected readonly IFakeIdGenerateService<User> _userIdGenerateService;
        protected readonly IFakeIdGenerateService<Album> _albumIdGenerateService;

        public UserDomainService(
            IRepository<User> userRepository,
            IRepository<Album> albumRepository)
        {
            if (userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));

            if (albumRepository == null)
                throw new ArgumentNullException(nameof(albumRepository));

            _userRepository = userRepository;
            _albumRepository = albumRepository;
            _userIdGenerateService = new FakeIdGenerateService<User>();
            _albumIdGenerateService = new FakeIdGenerateService<Album>();
        }


        public void AddUser(string name, string email, DateTime? date = null)
        {
            if (_userRepository.All().SingleOrDefault(x => x.Email == email) != null)
                throw new ArgumentException(
                    string.Format("User with email {0} already exist!",
                    email));

            var id = _userIdGenerateService.GetId(_userRepository);

            var user = new User(id, name, email, date);

            _userRepository.Add(user);
        }

        public void AddAlbum(User user, Album album)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (_userRepository.All().SingleOrDefault(x => x.Albums.Contains(album)) != null)
                throw new ArgumentException("Album already nested to user!");

            user.AddAlbum(album);
        }

        public void DeleteAlbum(User user, Album album)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (album == null)
                throw new ArgumentNullException(nameof(album));

            if (!user.Albums.Contains(album))
                throw new ArgumentException("User has not album");

            user.DeleteAlbum(album);

        }
    }
}
