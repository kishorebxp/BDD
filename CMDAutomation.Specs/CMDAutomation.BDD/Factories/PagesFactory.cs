using OpenQA.Selenium;
using CMDAutomation.BDD.PageObjects;
using CMDAutomation.BDD.PageObjects.Forecast;

namespace CMDAutomation.BDD.Factories
{
    public class PagesFactory
    {
        private LoginPageObjects _loginPageObjects;
        private HomePageObjects _homepageObjects;
        private ForecastPageObjects _forecastpageObjects;
        private readonly IWebDriver _driver;
        public PagesFactory(IWebDriver driver)
        {
            _driver = driver;
        }
        public LoginPageObjects LoginPage
        {
            get
            {
                return _loginPageObjects ?? (_loginPageObjects = new LoginPageObjects(_driver));
            }
        }
        public HomePageObjects HomePage
        {
            get
            {
                return _homepageObjects ?? (_homepageObjects = new HomePageObjects(_driver));
            }
        }
        public ForecastPageObjects ForeCastPage
        {
            get
            {
                return _forecastpageObjects ?? (_forecastpageObjects = new ForecastPageObjects(_driver));
            }
        }
    }
}