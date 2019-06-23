using IssuesTestSolution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

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
            httpsRequests.GetResponse();
        }

        [Then(@"response status should be (.*) ok")]
        public void ThenResponseStatusShouldBeOk(int p0)
        {
            ScenarioContext.Current.Pending();
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

        [When(@"I send a put request with the following request body")]
        public void WhenISendAPutRequestWithTheFollowingRequestBody(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"authenticated client is set for a retrieve repo issues request")]
        public void GivenAuthenticatedClientIsSetForARetrieveRepoIssuesRequest()
        {
            httpsRequests.CreateGetRequest();
        }

        [When(@"I send the get request")]
        public void WhenISendTheGetRequest()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
