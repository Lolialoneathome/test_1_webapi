using RestSharp;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new RestClient("https://localhost:44319/users");
            var token = new RestClient("https://localhost:44319/token/u/p");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "text/json");
            //request.AddHeader("Accept", "application/xml");

            IRestResponse myToken = token.Execute(request);


            var requestSecure = new RestRequest(Method.GET);
            requestSecure.AddHeader("Content-Type", "text/json");
            requestSecure.AddHeader("Authorization", "Bearer " + myToken.Content);

            IRestResponse users = client.Execute(requestSecure);
        }
    }
}
