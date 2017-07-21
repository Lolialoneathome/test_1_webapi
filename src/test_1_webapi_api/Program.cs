using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using test_1_webapi_Domain.Services;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.Entities;

namespace test_1_webapi_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            IUserDomainService userService = (IUserDomainService) ( host.Services.GetService(typeof(IUserDomainService)));
            userService.AddUser("keke", "kekemaikl");
            userService.AddUser("keke2", "kekemaikl2");


            IRepository<User> userRepo = (IRepository<User>)(host.Services.GetService(typeof(IRepository<User>)));
            IAlbumDomainService albumService = (IAlbumDomainService)(host.Services.GetService(typeof(IAlbumDomainService)));
            albumService.AddAlbum("nyanyanalbum1", userRepo.GetById(1));
            host.Run();
        }
    }
}
