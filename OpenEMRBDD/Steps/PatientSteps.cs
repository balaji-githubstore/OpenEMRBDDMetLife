using NUnit.Framework;
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
        private static string actualAlertText;


        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public PatientSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }

        [When(@"I mousehover on Patient/client")]
        public void WhenIMousehoverOnPatientClient()
        {
            AutomationHooks.driver.FindElement(By.XPath("//div[text()='Patient/Client']")).Click();
        }

        [When(@"I click on Patients")]
        public void WhenIClickOnPatients()
        {
            AutomationHooks.driver.FindElement(By.XPath("//div[text()='Patients']")).Click();
        }

        [When(@"I click on add new patient")]
        public void WhenIClickOnAddNewPatient()
        {
            AutomationHooks.driver.SwitchTo().Frame("fin");
            AutomationHooks.driver.FindElement(By.Id("create_patient_btn1")).Click();
            AutomationHooks.driver.SwitchTo().DefaultContent();
        }

        [When(@"I fill the form")]
        public void WhenIFillTheForm(Table table)
        {

            
            //Console.WriteLine(table.RowCount);
            //Console.WriteLine(table.Rows[0].Count);
            //Console.WriteLine(table.Rows[0]["firstname"]);
            //Console.WriteLine(table.Rows[0]["lastname"]);
            //Console.WriteLine(table.Rows[0]["gender"]);
            //Console.WriteLine(table.Rows[0]["dob"]);


            AutomationHooks.driver.SwitchTo().Frame("pat");
            //AutomationHooks.driver.FindElement(By.Id("form_fname")).SendKeys(table.Rows[0][0]);
            AutomationHooks.driver.FindElement(By.Id("form_fname")).SendKeys(table.Rows[0]["firstname"]);
            AutomationHooks.driver.FindElement(By.Id("form_lname")).SendKeys(table.Rows[0]["lastname"]);
            AutomationHooks.driver.FindElement(By.Id("form_DOB")).SendKeys(table.Rows[0]["dob"]);


            SelectElement selectGender = new SelectElement(AutomationHooks.driver.FindElement(By.Id("form_sex")));
            selectGender.SelectByText(table.Rows[0]["gender"]);


        }

        [When(@"I click on create new patient")]
        public void WhenIClickOnCreateNewPatient()
        {
            AutomationHooks.driver.FindElement(By.Id("create")).Click();
            AutomationHooks.driver.SwitchTo().DefaultContent();
        }

        [When(@"I click on confirm create patient")]
        public void WhenIClickOnConfirmCreatePatient()
        {
            AutomationHooks.driver.SwitchTo().Frame("modalframe");
            AutomationHooks.driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            AutomationHooks.driver.SwitchTo().DefaultContent();
        }

        [When(@"I store and handle the alert")]
        public void WhenIStoreAndHandleTheAlert()
        {

            if(scenarioContext.TryGetValue("addpatient",out string value))
            {
                Console.WriteLine(value);
            }

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(AutomationHooks.driver);
            wait.Timeout = TimeSpan.FromSeconds(40);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));

            wait.Until(x => x.SwitchTo().Alert());

            actualAlertText = AutomationHooks.driver.SwitchTo().Alert().Text;
            AutomationHooks.driver.SwitchTo().Alert().Accept();


        }

        [When(@"I close the pop when available")]
        public void WhenICloseThePopWhenAvailable()
        {
            if (AutomationHooks.driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count > 0)
            {
                AutomationHooks.driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }
        }

        [Then(@"I should validate the alert message shown as '(.*)'")]
        public void ThenIShouldValidateTheAlertMessageShownAs(string expectedAlertText)
        {
            Assert.IsTrue(actualAlertText.Contains(expectedAlertText)); //should be true
        }

        [Then(@"I should get the added patient details as '(.*)'")]
        public void ThenIShouldGetTheAddedPatientDetailsAs(string expectedValue)
        {
            AutomationHooks.driver.SwitchTo().Frame("pat");
            Assert.AreEqual(expectedValue, AutomationHooks.driver.FindElement(By.TagName("h2")).Text);
        }



        [Given(@"I started the test")]
        public void GivenIStartedTheTest()
        {

        }

        [When(@"I fill the detail")]
        public void WhenIFillTheDetail(Table table)
        {
            scenarioContext.Add("dtrecord", table);
            scenarioContext.Add("name", "bala");


            Console.WriteLine(table.Rows[0].Count);
            Console.WriteLine(table.Rows[0]["firstname"]);
            Console.WriteLine(table.Rows[0]["lastname"]);
            Console.WriteLine(table.Rows[0]["gender"]);
            Console.WriteLine(table.Rows[0]["dob"]);


            Console.WriteLine(table.Rows[1].Count);
            Console.WriteLine(table.Rows[1]["firstname"]);
            Console.WriteLine(table.Rows[1][0]);
            Console.WriteLine(table.Rows[1]["lastname"]);
            Console.WriteLine(table.Rows[1]["gender"]);
            Console.WriteLine(table.Rows[1]["dob"]);

            for (int r = 0; r < table.RowCount; r++)
            {
                Console.WriteLine(table.Rows[r]["firstname"]);
                Console.WriteLine(table.Rows[r]["lastname"]);
                Console.WriteLine(table.Rows[r]["gender"]);
                Console.WriteLine(table.Rows[r]["dob"]);
            }

            for (int r = 0; r < table.RowCount; r++)
            {
                for (int c = 0; c < table.Rows[r].Count; c++)
                {
                    Console.WriteLine(table.Rows[r][c]);
                }
            }


            //foreach(TableRow row in table.Rows)
            //{
            //    Console.WriteLine(row[0]);
            //    Console.WriteLine(row["fistname"]);
            //}
        }

        [Then(@"I should get")]
        public void ThenIShouldGet()
        {
            if (scenarioContext.TryGetValue("dtrecod", out Table dt))
            {
                Console.WriteLine(dt.RowCount);
            }

            if(scenarioContext.TryGetValue("name",out string name))
            {
                Console.WriteLine(name);
            }
        }

    }
}
