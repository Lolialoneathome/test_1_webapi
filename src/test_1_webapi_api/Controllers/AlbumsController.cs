﻿using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.Entities;

namespace test_1_webapi_api.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : EntityController<Album>
    {
        public AlbumsController(IRepository<Album> repository) : base(repository)
        {
        }
    }
}