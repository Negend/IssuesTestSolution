using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution.Helpers
{
    public class HttpRequests
    {
        IGithubSettings Settings { get; set; }
        public static RestClient client;
        public static RestRequest restRequest;
        //public static string baseUrl = "https://api.github.com";
        const string createEndpoint = "g";

        public HttpRequests(IGithubSettings settings)
        {
            Settings = settings;
            client = new RestClient(Settings.BaseUrl);
        }

        public RestRequest CreateGetRequest()
        {
            restRequest = new RestRequest(Resource("IssueList"),Method.GET);
            restRequest.AddHeader("Authorization", Settings.GitToken);
            return restRequest;
        }

        public RestRequest CreatePostRequest()
        {
            restRequest = new RestRequest(Resource("Create"), Method.GET);
            restRequest.AddHeader("Authorization", Settings.GitToken);
            return restRequest;
        }

        public RestRequest CreatePatchRequest()
        {
            restRequest = new RestRequest(Resource("Edit"), Method.GET);
            restRequest.AddHeader("Authorization", Settings.GitToken);
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }

        string Resource(string type, int issueNumber = 0)
        {
            switch (type)
            {
                case "Create":
                    return $"/repos/{Settings.GitUser}/{Settings.GithubRepo}/issues";
                case "Edit":
                    return $"/repos/{Settings.GitUser}/{Settings.GithubRepo}/issues/{issueNumber}";
                case "IssueList":
                    return $"/repos/{Settings.GitUser}/{Settings.GithubRepo}/issues";
                default:
                    throw new Exception("unsupported resource type");
            }
        }
    }
}
