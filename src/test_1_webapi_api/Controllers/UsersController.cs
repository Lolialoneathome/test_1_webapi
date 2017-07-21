using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.Entities;
using test_1_webapi_Domain.Services;

namespace test_1_webapi_api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : EntityController<User>
    {
        public UsersController(IRepository<User> repository) : base(repository)
        {
            
        }


        // GET api/users/5/albums
        [HttpGet("{id}/albums")]
        public IEnumerable<Album> GetAlbums(int id)
        {
            return _repository.GetById(id).Albums;
        }

    }
}
