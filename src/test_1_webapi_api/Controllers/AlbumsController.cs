using Microsoft.AspNetCore.Mvc;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;

namespace test_1_webapi_api.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : ModelController<Album>
    {
        public AlbumsController(IRepository<Album> repository) : base(repository)
        {
        }
    }
}
