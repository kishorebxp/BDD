using System.Configuration;
namespace CMDAutomation.BDD
{
    public static class TestParameters
    {
        public static string Browser
        {
            get { return ConfigurationManager.AppSettings["Browser"]; }
        }
        public static string AUT
        {
            get { return ConfigurationManager.AppSettings["URL"]; }
        }
        public static string UserName
        {
            get { return ConfigurationManager.AppSettings["UserName"]; }
        }
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["Password"]; }
        }
    }
}