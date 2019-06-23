using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution.Steps.model
{
    public class IssueDetails
    {
        public string title { get; set; }
        public string body { get; set; }
        public string[] labels;
    }
}
