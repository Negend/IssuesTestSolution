using BoDi;
using IssuesTestSolution.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTestSolution
{
    public static class Registrations
    {
        public static void Register(IObjectContainer objectContainer)
        {
            objectContainer.RegisterTypeAs<GithubSettings, IGithubSettings>();
        }
    }
}
