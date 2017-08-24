using System.IO;
using System.Reflection;

namespace CMDAutomationTestHelper
{
    public static class PathHelper
    {
        public static string GetCurrentDirectory
        {
            get
            {
                return Path.GetDirectoryName(Path.Combine(Assembly.GetExecutingAssembly().Location));
            }
        }
    }
}