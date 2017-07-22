using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace test_1_webapi_api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class UsersController : ModelController<User>
    {
        protected readonly IRepository<Album> _albumsRepository;

        public UsersController(IRepository<User> userRepository, IRepository<Album> albumsRepository) : base(userRepository)
        {
            if (albumsRepository == null)
                throw new ArgumentNullException(nameof(albumsRepository));

            _albumsRepository = albumsRepository;
        }


        //GET api/users/5/albums
        [HttpGet("{id}/albums")]
        public IEnumerable<Album> GetAlbums(int id)
        {
            return _albumsRepository.All().Where(x => x.UserId == id);
        }

    }
}
