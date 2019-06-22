using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution.Helpers
{
    public static class HttpRequests
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = "";

        public static RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            return client = new RestClient(url);

        }

        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/vnd.github.v3+json");
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }
    }
}
