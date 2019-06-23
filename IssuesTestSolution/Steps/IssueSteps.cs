using IssuesTestSolution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using IssuesTestSolution.Steps.model;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Net;
using TechTalk.SpecFlow.Assist;

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
        public void WhenISendAPostRequestWithTheFollowingRequestBody(IssueDetails body)
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
        public void WhenISendAPutRequestWithTheFollowingRequestBody(IssueDetails body)
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
        private IssueDetails UserTableTransform(Table table)
        {
            IssueDetails body = table.CreateInstance<IssueDetails>();
            foreach (var row in table.Rows)
            {
                if (row[0] == "labels")
                {
                    body.labels = row[1].Split(',');
                }
            }
            return body;
        }

    }
}