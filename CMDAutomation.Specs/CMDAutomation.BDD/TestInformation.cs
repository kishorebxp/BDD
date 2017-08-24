using OpenQA.Selenium;
using CMDAutomation.BDD.Factories;
using CMDReportGenerator.ConcreteClasses;
using System.Configuration;

namespace CMDAutomation.BDD
{
    public class TestInformation
    {
        private PagesFactory _pageFactory;
        private readonly IWebDriver _driver;
        public TestInformation(IWebDriver driver)
        {
            _driver = driver;
        }
        public PagesFactory PageFactory
        {
            get
            {
                return _pageFactory ?? (_pageFactory = new PagesFactory(_driver));
            }
        }
    }
}