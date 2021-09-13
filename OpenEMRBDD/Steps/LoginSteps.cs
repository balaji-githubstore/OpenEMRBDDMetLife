using System;
using TechTalk.SpecFlow;

namespace OpenEMRBDD.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I have browser with openemr page")]
        public void GivenIHaveBrowserWithOpenemrPage()
        {
            Console.WriteLine("given - browser launch");
        }
        
        [When(@"I enter username as ""(.*)""")]
        public void WhenIEnterUsernameAs(string p0)
        {
            Console.WriteLine("username");
        }
        
        [When(@"I enter password as ""(.*)""")]
        public void WhenIEnterPasswordAs(string p0)
        {
            
        }
        
        [When(@"I select language as ""(.*)""")]
        public void WhenISelectLanguageAs(string p0)
        {
            
        }
        
        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            Console.WriteLine("login");
        }
        
        [Then(@"I should get access to the portal with title as ""(.*)""")]
        public void ThenIShouldGetAccessToThePortalWithTitleAs(string p0)
        {
            
        }
    }
}
