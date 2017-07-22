using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;
using System;

namespace test_1_webapi_api.Controllers
{
    public abstract class EntityController<TEntity> : Controller
        where TEntity : IModel
    {
        protected readonly IRepository<TEntity> _repository;

        public EntityController(IRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }
        // GET api/~
        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _repository.All();
        }

        // GET api/~/5
        [HttpGet("{id}")]
        public TEntity Get(int id)
        {
            return _repository.GetById(id);
        }

    }
}
