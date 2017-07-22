using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace test_1_webapi_api.Controllers
{
    public abstract class ModelController<TModel> : Controller
        where TModel : IModel
    {
        protected readonly IRepository<TModel> _repository;

        public ModelController(IRepository<TModel> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }
        // GET api/~
        [HttpGet]
        public IEnumerable<TModel> Get()
        {
            return _repository.All();
        }

        // GET api/~/5
        [HttpGet("{id}")]
        public TModel Get(int id)
        {
            return _repository.GetById(id);
        }

    }
}
