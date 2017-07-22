﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;
using System;
using System.Linq;

namespace test_1_webapi_api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : EntityController<User>
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
