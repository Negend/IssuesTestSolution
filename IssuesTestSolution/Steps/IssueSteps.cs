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

        public IssueSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [Given(@"client is authenticated")]
        public void GivenClientIsAuthenticated()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I send a post request with the following request body")]
        public void WhenISendAPostRequestWithTheFollowingRequestBody(Table table)
        {
            ScenarioContext.Current.Pending();
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

        [When(@"I send a put request with the following request body")]
        public void WhenISendAPutRequestWithTheFollowingRequestBody(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I send the get request")]
        public void WhenISendTheGetRequest()
        {
            ScenarioContext.Current.Pending();
        }
        [Given(@"following endpoint is set for a create issue request")]
        public void GivenFollowingEndpointIsSetForACreateIssueRequest()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"following endpoint is set for an edit issue request")]
        public void GivenFollowingEndpointIsSetForAnEditIssueRequest()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"following endpoint is set for a retrieve repo issues request")]
        public void GivenFollowingEndpointIsSetForARetrieveRepoIssuesRequest()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
