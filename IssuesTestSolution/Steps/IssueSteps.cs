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
        private ContextProperties contextProperties;

        public IssueSteps(IGithubSettings settings, ContextProperties _contextProperties)
        {
            httpsRequests = new HttpRequests(settings);
            contextProperties = _contextProperties;
        }

        [Given(@"authenticated client is set for a create issue request")]
        public void GivenAuthenticatedClientIsSetForACreateIssueRequest()
        {
            httpsRequests.CreatePostRequest(); 
        }

        [Given(@"the first issue created has title (.*)")]
        public void GivenTheFirstIssueCreatedHasTitleHello(string title)
        {
            contextProperties.IssueTitle = title;
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
                httpsRequests.GetResponseStatus().Should().Be(HttpStatusCode.OK);
            }
            else if (code == 201)
            {
                httpsRequests.GetResponseStatus().Should().Be(HttpStatusCode.Created);
            }
            else
            {
                throw new Exception("wrong code tested in feature file");
            }
        }
         
        [Then(@"response body contains issue information")]
        public void ThenResponseBody()
        {
            httpsRequests.GetResponseIssueInfo().body.Should().Be(contextProperties.IssueBody);
            httpsRequests.GetResponseIssueInfo().title.Should().Be(contextProperties.IssueTitle);
            contextProperties.IssueNumber = httpsRequests.GetResponseIssueInfo().number;
        }

        [Given(@"authenticated client is set for an edit issue (.*) request")]
        public void GivenAuthenticatedClientIsSetForAnEditIssueRequest(int issueNum)
        {
            httpsRequests.CreatePatchRequest(issueNum);
            contextProperties.IssueNumber = issueNum;
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

        [Then(@"response body contains a list of issues")]
        public void ThenResponseBodyContainsAListOfIssues()
        {
            httpsRequests.GetResponseIssues().Last().title.Should().Be(contextProperties.IssueTitle);
            httpsRequests.GetResponseIssues().Last().number.Should().Be(contextProperties.IssueNumber);
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

            contextProperties.IssueBody = body.body;
            contextProperties.IssueTitle = body.title;
            return body;
        }

    }
}