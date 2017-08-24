using BoDi;
using CMDAutomation.BDD.ExtensionMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using CMDAutomation.BDD.Enums;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using CMDReportGenerator.ConcreteClasses;
using System.Configuration;
using CMDAutomation.BDD.Factories;

namespace CMDAutomation.BDD
{
    public class LocalReport
    {
        public void StartHtmlReport()
        {
            Reporter.Report.StartHtmlReport("TESTREPORT", "AutomationReport");
        }      
        
        public void GenerateHtmlReport()
        {
            Reporter.Report.GenerateHtmlReport();
        }  
    }

    [Binding]
    public class Hooks : IDisposable
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private TestInformation _testInfo;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            SelectBrowser(TestParameters.Browser);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Manage().Window.Maximize();
            _testInfo = new TestInformation(_driver);
            _objectContainer.RegisterInstanceAs(_testInfo);
        }

        [AfterScenario]
        public void CleanUp()
        {
           //TODO! - Write After Scenario logic
        }

        [BeforeTestRun]
        public static void BeforeEveryTestRun()
        {
            new LocalReport().StartHtmlReport();
            //Reporter.Report.StartHtmlReport("TESTREPORT", "AutomationReport");            
        }

        [AfterTestRun]
        public static void AfterEveryTestRun()
        {
            new LocalReport().GenerateHtmlReport();
        }

        private void SelectBrowser(string browser)
        {
            switch (browser.ToEnumType<BrowserType>())
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    _driver = new ChromeDriver(option);
                    _objectContainer.RegisterInstanceAs(_driver);
                    break;
                case BrowserType.Firefox:
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    _driver = new FirefoxDriver(service);
                    _objectContainer.RegisterInstanceAs(_driver);
                    break;
                case BrowserType.IE:
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _testInfo = null;
        }
    }
}
