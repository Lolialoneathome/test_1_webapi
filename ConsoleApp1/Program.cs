using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("localost:5000/users");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
        }
    }
}
