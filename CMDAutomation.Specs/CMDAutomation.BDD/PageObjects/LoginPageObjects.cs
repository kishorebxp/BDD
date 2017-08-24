using OpenQA.Selenium;
using CMDObjectRepository.Insight;

namespace CMDAutomation.BDD.PageObjects
{
    public class LoginPageObjects
    {
        private readonly IWebDriver _driver;
        public LoginPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UserNameField
        {
            get { return _driver.FindElement(By.Id(LoginPage.UserNameTextBoxID)); }
        }

        public IWebElement PasswordField
        {
            get { return _driver.FindElement(By.Id(LoginPage.PasswordTextBoxID)); }
        }
        public IWebElement LoginButton
        {
            get { return _driver.FindElement(By.Id(LoginPage.LoginButtonID)); }
        }
    }
}
