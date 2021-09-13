using NUnit.Framework;
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
        IWebDriver driver;

        [Given(@"I have browser with open emr page")]
        public void GivenIHaveBrowserWithOpenemrPage()
        {
            driver = new ChromeDriver(@"C:\Components");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }
        
        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
        }
        
        [When(@"I enter password as '(.*)'")]
        public void WhenIEnterPasswordAs(string password)
        {
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
        }
        
        [When(@"I select language as '(.*)'")]
        public void WhenISelectLanguageAs(string language)
        {
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.Name("languageChoice")));
            selectLanguage.SelectByText(language);
        }
        
        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I should get access to the portal with title as '(.*)'")]
        public void ThenIShouldGetAccessToThePortalWithTitleAs(string expectedValue)
        {
            //wait for page load 
            Assert.AreEqual(expectedValue, driver.Title);
            driver.Quit();
        }

        [Then(@"I should get error message as '(.*)'")]
        public void ThenIShouldGetErrorMessageAs(string expectedValue)
        {
            Assert.AreEqual(expectedValue, driver.FindElement(By.XPath("//*[contains(text(),'Invalid')]")).Text);
            driver.Quit();
        }



    }
}
