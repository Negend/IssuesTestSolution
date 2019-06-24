using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using IssuesTestSolution.Helpers;
using TechTalk.SpecFlow;

namespace IssuesTestSolution.Hooks
{
    [Binding]
    public sealed class GlobalHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        IObjectContainer _objectContainer;
        IGithubSettings _githubSettings;
        public GlobalHooks(IObjectContainer objectContainer)
        {
            Registrations.Register(objectContainer);
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeTestRun()
        {
            _githubSettings = _objectContainer.Resolve<IGithubSettings>();
        }
    }
}
