using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution.Helpers
{
    public class GithubSettings : IGithubSettings
    {
        public string BaseUrl => ConfigurationManager.AppSettings[nameof(BaseUrl)];
        public string GitToken => ConfigurationManager.AppSettings[nameof(GitToken)];
        public string GithubRepo => ConfigurationManager.AppSettings[nameof(GithubRepo)];
        public string GitUser => ConfigurationManager.AppSettings[nameof(GitUser)];

    }
}