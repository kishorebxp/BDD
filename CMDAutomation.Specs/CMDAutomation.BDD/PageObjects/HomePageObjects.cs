using OpenQA.Selenium;

namespace CMDAutomation.BDD.PageObjects
{
    public class HomePageObjects
    {
        private readonly IWebDriver _driver;
        public HomePageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SnapShotLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.DashboardLinkID)); }
        }

        public IWebElement ForecastLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.ForecastLinkID)); }
        }

        public IWebElement AnalyzeLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.AnalyzeLinkID)); }
        }

        public IWebElement LeadsLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.LeadsLinkID)); }
        }

        public IWebElement TrackLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.TrackLinkID)); }
        }

        public IWebElement ExportLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.ExportLinkID)); }
        }

        public IWebElement PulseLink
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Insight.Modules.PulseLinkID)); }
        }
    }
}
