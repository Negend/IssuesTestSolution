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

        private readonly ScenarioContext context;
        private HttpRequests httpsRequests;

        public IssueSteps(ScenarioContext injectedContext, IGithubSettings settings)
        {
            httpsRequests = new HttpRequests(settings);
        }
        [Given(@"authenticated client is set for a create issue request")]
        public void GivenAuthenticatedClientIsSetForACreateIssueRequest()
        {
            httpsRequests.CreatePostRequest(); 
        }

        [When(@"I send a post request with the following request body")]
        public void WhenISendAPostRequestWithTheFollowingRequestBody(Table table)
        {
            httpsRequests.AddJsonBody(table);
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
            ScenarioContext.Current.Pending();
        }

        [Given(@"authenticated client is set for an edit issue request")]
        public void GivenAuthenticatedClientIsSetForAnEditIssueRequest()
        {
            httpsRequests.CreatePatchRequest();
        }

        [When(@"I send a patch request with the following request body")]
        public void WhenISendAPutRequestWithTheFollowingRequestBody(Table table)
        {
            httpsRequests.AddJsonBody(table);
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

    }
}
