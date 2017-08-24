using CMDAutomation.BDD.ExtensionMethods;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using CMDAutomation.BDD.Enums;
using CMDReportGenerator;
using CMDReportGenerator.ConcreteClasses;
using CMDAutomation.BDD.Factories;

namespace CMDAutomation.BDD.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private TestInformation _testInfo;
        private Reporter _reporter = Reporter.Report;
        public LoginSteps(IWebDriver driver,TestInformation testInfo)
        {
            _driver = driver;
            _testInfo = testInfo;
            _reporter.CreateScenario(FeatureContext.Current.FeatureInfo.Title, ScenarioContext.Current.ScenarioInfo.Title, "Scenario");
        }

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            //Launch browser and Go to URL
            _driver.Navigate().GoToUrl(TestParameters.AUT);

            //Login with the credentials
            _testInfo.PageFactory.LoginPage.UserNameField.SendKeys(TestParameters.UserName);
            _testInfo.PageFactory.LoginPage.PasswordField.SendKeys(TestParameters.Password);
            _testInfo.PageFactory.LoginPage.LoginButton.Submit();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _reporter.CreateStepResults("Given", TestStatus.Pass, "I navigate to application");
        }

        [Given(@"navigate to '(.*)' module")]
        public void GivenINavigateToModule(string moduleName)
        {
            var requiredModule = ModuleIdAutomationLookup(moduleName.ToEnumType<Modules>());
            requiredModule.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(2000);
            _reporter.CreateStepResults("Given", TestStatus.Pass, "I navigate to " + moduleName + " application");
        }

        #region Private Helpers
        private IWebElement ModuleIdAutomationLookup(Modules moduleName)
        {
            switch (moduleName)
            {
                case Modules.Forecast:
                    return _testInfo.PageFactory.HomePage.ForecastLink;
                case Modules.Leads:
                    return _testInfo.PageFactory.HomePage.LeadsLink;
                case Modules.Analyze:
                    return _testInfo.PageFactory.HomePage.AnalyzeLink;
                case Modules.Pulse:
                    return _testInfo.PageFactory.HomePage.PulseLink;
                case Modules.Track:
                    return _testInfo.PageFactory.HomePage.TrackLink;
                default:
                    throw new NotSupportedException("Specified module type is not supported " + moduleName);
            }
        }
        #endregion
    }
}