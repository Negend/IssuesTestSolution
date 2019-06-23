using System;

namespace IssuesTestSolution.Helpers
{
    public interface IGithubSettings
    {
        string GithubRepo { get; }
        string GitToken { get; }
        string BaseUrl { get; }
        string GitUser { get; }
    }
}