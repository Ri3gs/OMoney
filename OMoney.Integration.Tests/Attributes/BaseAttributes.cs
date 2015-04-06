using System;
using NUnit.Framework;

namespace OMoney.Integration.Tests.Attributes
{
    class BaseAttributes : Attribute, ITestAction
    {
        public void AfterTest(TestDetails testDetails)
        {
            BaseIntegrationTest test = testDetails.Fixture as BaseIntegrationTest;

        }

        public void BeforeTest(TestDetails testDetails)
        {
            BaseIntegrationTest test = testDetails.Fixture as BaseIntegrationTest;

        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}
