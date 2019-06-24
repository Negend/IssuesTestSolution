using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace IssuesTestSolution.Helpers
{
    public class ContextProperties
    {
        public string IssueTitle { get; set; }
        public string IssueBody { get; set; }
        public int IssueNumber { get; set; }
    }
}
