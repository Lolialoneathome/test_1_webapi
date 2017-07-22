using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {

        protected static string apiPath = "http://jsonplaceholder.typicode.com/users";
        public static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();
            //var response = client.GetAsync("http://google.com").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    // by calling .Result you are performing a synchronous call
            //    var responseContent = response.Content;

            //    // by calling .Result you are synchronously reading the result
            //    string responseString = responseContent.ReadAsStringAsync().Result;

            //    Console.WriteLine(responseString);
            //}
            //using (var httpClient = new HttpClient())
            //{
            //    var json = httpClient.GetStringAsync(apiPath);

            //    // Now parse with JSON.Net
            //}
            var client = new RestClient(apiPath);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //Console.ReadLine();
            //Task T = new Task(ApiCall);
            //T.Start();
            //Console.WriteLine("Json data........");
            //Console.ReadLine();
            ////string URL = "http://gitlab.company.com/api/v3/users?per_page=100&page=1";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiPath);
            //request.ContentType = "application/json; charset=utf-8";
            ////request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            ////request.PreAuthenticate = true;
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //using (Stream responseStream = response.GetResponseStream())
            //{
            //    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            //    Console.WriteLine(reader.ReadToEnd());
            //}
        }

        static async void ApiCall()
        {

            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(apiPath);

                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                }

            }
        }
    }
}
