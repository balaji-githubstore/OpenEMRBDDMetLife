using OpenEMRBDD.Hooks;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace OpenEMRBDD.Steps
{
    [Binding]
    [Scope(Feature = "ChangePassword")]
    class ChangePasswordSteps
    {

        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public ChangePasswordSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }

        [Scope(Feature = "ChangePassword",Scenario = "Change Password Scenario",Tag ="@password")]
        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            
            //AutomationHooks.driver.FindElement(By.Id("clearPass")).SendKeys(password);
            if (scenarioContext.TryGetValue("dtrecod", out Table dt))
            {
                Console.WriteLine(dt.RowCount);
            }

            if (scenarioContext.TryGetValue("name", out string name))
            {
                Console.WriteLine(name);
            }
        }
    }
}
