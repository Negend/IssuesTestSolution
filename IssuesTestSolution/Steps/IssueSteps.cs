using IssuesTestSolution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Net;

namespace IssuesTestSolution.Steps
{
    [Binding]
    public sealed class IssueSteps
    {
        
        private HttpRequests httpsRequests;

        public IssueSteps(IGithubSettings settings)
        {
            httpsRequests = new HttpRequests(settings);
        }
        [Given(@"authenticated client is set for a create issue request")]
        public void GivenAuthenticatedClientIsSetForACreateIssueRequest()
        {
            httpsRequests.CreatePostRequest(); 
        }

        [When(@"I send a post request with the following request body")]
        public void WhenISendAPostRequestWithTheFollowingRequestBody(List<JsonValues> body)
        {
            httpsRequests.AddJsonBody(body);
            httpsRequests.SendRequest();
        }

        [Then(@"success response status should be (.*)")]
        public void ThenResponseStatusShouldBeOk(int code)
        {
            if (code == 200)
            {
                httpsRequests.GetResponseStatus(httpsRequests.restResponse).Should().Be(HttpStatusCode.OK);
            }
            else if (code == 201)
            {
                httpsRequests.GetResponseStatus(httpsRequests.restResponse).Should().Be(HttpStatusCode.Created);
            }
            else if (code == 202)
            {
                httpsRequests.GetResponseStatus(httpsRequests.restResponse).Should().Be(HttpStatusCode.Accepted);
            }
            else
            {
                throw new Exception("wrong code tested in feature file");
            }
        }
         
        [Then(@"response body")]
        public void ThenResponseBody()
        {
           
        }

        [Given(@"authenticated client is set for an edit issue (.*) request")]
        public void GivenAuthenticatedClientIsSetForAnEditIssueRequest(int issue)
        {
            httpsRequests.CreatePatchRequest(issue);
        }

        [When(@"I send a patch request with the following request body")]
        public void WhenISendAPutRequestWithTheFollowingRequestBody(List<JsonValues> body)
        {
            httpsRequests.AddJsonBody(body);
            httpsRequests.SendRequest();
        }

        [Given(@"authenticated client is set for a retrieve repo issues request")]
        public void GivenAuthenticatedClientIsSetForARetrieveRepoIssuesRequest()
        {
            httpsRequests.CreateGetRequest();
        }

        [When(@"I send the get request")]
        public void WhenISendTheGetRequest()
        {
             httpsRequests.SendRequest();
        }


        [StepArgumentTransformation(@"(.*) body")]
        private List<JsonValues> UserTableTransform(Table table)
        {
            List<JsonValues> body = new List<JsonValues>();
            foreach (var row in table.Rows)
            {
                body.Add(new JsonValues(row["name"], row["value"]));
            }
                return body;
        }
        
    }
}