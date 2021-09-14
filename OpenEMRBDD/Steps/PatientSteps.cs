using OpenEMRBDD.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace OpenEMRBDD.Features
{
    [Binding]
    public class PatientSteps
    {
        [When(@"I mousehover on Patient/client")]
        public void WhenIMousehoverOnPatientClient()
        {
            
        }
        
        [When(@"I click on Patients")]
        public void WhenIClickOnPatients()
        {
            
        }
        
        [When(@"I click on add new patient")]
        public void WhenIClickOnAddNewPatient()
        {
            
        }
        
        [When(@"I fill the form")]
        public void WhenIFillTheForm(Table table)
        {
            Console.WriteLine("hellp");

            Console.WriteLine(table.RowCount);
            Console.WriteLine(table.Rows[0].Count);

            Console.WriteLine(table.Rows[0]["firstname"]);
            Console.WriteLine(table.Rows[0]["lastname"]);
            Console.WriteLine(table.Rows[0]["gender"]);
            Console.WriteLine(table.Rows[0]["dob"]);



            
        }
        
        [When(@"I click on create new patient")]
        public void WhenIClickOnCreateNewPatient()
        {
            
        }
        
        [When(@"I click on confirm create patient")]
        public void WhenIClickOnConfirmCreatePatient()
        {
            
        }
        
        [When(@"I store and handle the alert")]
        public void WhenIStoreAndHandleTheAlert()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(AutomationHooks.driver);
            wait.Timeout = TimeSpan.FromSeconds(40);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(Exception));


            wait.Until(x=>x.SwitchTo().Alert());


            String alertText = AutomationHooks.driver.SwitchTo().Alert().Text;
            AutomationHooks.driver.SwitchTo().Alert().Accept();


            wait.Until(x => x.FindElement(By.XPath("")));

            AutomationHooks.driver.FindElement(By.XPath("")).Click();

        }
        
        [When(@"I close the pop when available")]
        public void WhenICloseThePopWhenAvailable()
        {
            
        }

        [Then(@"I should validate the alert message shown as '(.*)'")]
        public void ThenIShouldValidateTheAlertMessageShownAs(string expectedAlertText)
        {
           
        }

        [Then(@"I should get the added patient details as '(.*)'")]
        public void ThenIShouldGetTheAddedPatientDetailsAs(string expectedValue)
        {
          
        }

    }
}
