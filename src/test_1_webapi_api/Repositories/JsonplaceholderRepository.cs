using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using test_1_webapi_Domain.DataModels;
using test_1_webapi_Domain.Repositories;

namespace test_1_webapi_api.Repositories
{
    public class JsonplaceholderRepository<TEntity> : IRepository<TEntity>
        where TEntity : IModel
    {
        protected string _apiUrl;

        public JsonplaceholderRepository(string apiUrl)
        {
            if (apiUrl == null)
                throw new ArgumentNullException(nameof(apiUrl));

            _apiUrl = apiUrl;
        }

        protected string GetData()
        {
            var client = new RestClient(_apiUrl);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> All()
        {
            string json = GetData();

            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);
        }

        public TEntity GetById(int id)
        {
            string json = GetData();

            var all = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(json);

            return all.SingleOrDefault(x => x.Id == id);
        }
    }
}
