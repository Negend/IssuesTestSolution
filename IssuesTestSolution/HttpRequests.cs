using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssuesTestSolution.Helpers;
using BoDi;
using System.Net;
using IssuesTestSolution.Steps.model;
using Newtonsoft.Json;

namespace IssuesTestSolution
{
    public class HttpRequests
    {
        IGithubSettings Settings { get; set; }
        public RestClient client;
        public RestRequest restRequest;
        public IRestResponse restResponse;
        private readonly string personalToken;
        private string Token => "token " + personalToken;

        public HttpRequests(IGithubSettings settings)
        {
            Settings = settings;
            client = new RestClient(Settings.BaseUrl);
            personalToken = Settings.GitToken;

            //Resolves certificate issue
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        
        public RestRequest CreateGetRequest()
        {
            restRequest = new RestRequest(Resource("IssueList"), Method.GET);
            restRequest.AddHeader("Authorization", Token);
            return restRequest;
        }

        public RestRequest CreatePostRequest()
        {
            restRequest = new RestRequest(Resource("Create"), Method.POST);
            restRequest.AddHeader("Authorization", Token);
            return restRequest;
        }

        public RestRequest CreatePatchRequest(int issue)
        {
            restRequest = new RestRequest(Resource("Edit",issue), Method.PATCH);
            restRequest.AddHeader("Authorization", Token);

            return restRequest;
        }

        public void AddJsonBody(IssueDetails body)
        {
            restRequest.AddJsonBody(body);
        }

        public IRestResponse SendRequest()
        {
            return restResponse = client.Execute(restRequest);
        }

        public HttpStatusCode GetResponseStatus()
        {
            return restResponse.StatusCode;
        }

        public IssueResponse GetResponseIssueInfo()
        {
            return JsonConvert.DeserializeObject<IssueResponse>(restResponse.Content);
        }
        public List<IssueResponse> GetResponseIssues()
        {
            return JsonConvert.DeserializeObject<List<IssueResponse>>(restResponse.Content);
        }

        public object GetIssueNumber()
        {
            return restResponse.Content;
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
