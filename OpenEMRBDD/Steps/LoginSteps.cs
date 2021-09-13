using NUnit.Framework;
using OpenEMRBDD.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace OpenEMRBDD.Steps
{
    [Binding]
    public class LoginSteps 
    {
        [Given(@"I have browser with open emr page")]
        public void GivenIHaveBrowserWithOpenemrPage()
        {
            AutomationHooks.driver = new ChromeDriver(@"C:\Components");
            AutomationHooks.driver.Manage().Window.Maximize();
            AutomationHooks.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AutomationHooks.driver.Url = "https://demo.openemr.io/b/openemr";
        }

        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            AutomationHooks.driver.FindElement(By.Id("authUser")).SendKeys(username);
        }
        
        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            AutomationHooks.driver.FindElement(By.Id("clearPass")).SendKeys(password);
        }
        
        [When(@"I select language as '(.*)'")]
        public void WhenISelectLanguageAs(string language)
        {
            SelectElement selectLanguage = new SelectElement(AutomationHooks.driver.FindElement(By.Name("languageChoice")));
            selectLanguage.SelectByText(language);
        }
        
        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I should get access to the portal with title as '(.*)'")]
        public void ThenIShouldGetAccessToThePortalWithTitleAs(string expectedValue)
        {
            //wait for page load 
            Assert.AreEqual(expectedValue, AutomationHooks.driver.Title);
        }

        [Then(@"I should get error message as '(.*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedValue)
        {
            Assert.AreEqual(expectedValue, AutomationHooks.driver.FindElement(By.XPath("//*[contains(text(),'Invalid')]")).Text);
        }
    }
}
