using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace CMDReportGenerator.ConcreteClasses
{
    public class TestReport
    {
        public ExtentTest _scenario;
        public ExtentTest _feature;
        public TestReport(string featureName, string scenarioName, string gherkinKeyword, string description = null)
        {
            //Feature
            _feature = Reporter.Report.Extent.CreateTest(featureName);
            //Scenario
            _scenario = _feature.CreateNode(new GherkinKeyword(gherkinKeyword), scenarioName);
        }
    }

    public class Reporter
    {
        private static string reportPath = ConfigurationManager.AppSettings["ReportPath"];
        private static Reporter _reporter=null;
        public static Reporter Report{
            get
            {
                return _reporter??(_reporter = new Reporter(reportPath));
            }
        }

        public ExtentReports Extent { get; set; }
        private readonly string _reportPath;
        private ExtentHtmlReporter _htmlReporter;
        //private ExtentTest _scenario;
        //private ExtentTest _feature;

        private static Dictionary<int, TestReport> reportThreadMap = new Dictionary<int, TestReport>();

        public static ExtentTest _scenario
        {
            get
            {
                return reportThreadMap[Thread.CurrentThread.ManagedThreadId]._scenario;
            }
        }

        public Reporter(string reportPath)
        {
            Extent = new ExtentReports();
            _reportPath = reportPath;
        }

        public void StartHtmlReport(string documentTitle, string reportName)
        {
            _htmlReporter = new ExtentHtmlReporter(_reportPath);
            _htmlReporter.Start();
            _htmlReporter.Configuration().Theme = Theme.Dark;
            _htmlReporter.Configuration().DocumentTitle = documentTitle;
            _htmlReporter.Configuration().ReportName = reportName;
            Extent.AttachReporter(_htmlReporter);
        }

        public void GenerateHtmlReport()
        {
            Extent.Flush();
        }

        public void CreateScenario(string featureName, string scenarioName, string gherkinKeyword, string description = null)
        {
            ////Feature
            //_feature = _extent.CreateTest(featureName);
            ////Scenario
            //_scenario = _feature.CreateNode(new GherkinKeyword(gherkinKeyword), scenarioName);
            reportThreadMap.Add(Thread.CurrentThread.ManagedThreadId, new TestReport(featureName, scenarioName, gherkinKeyword, description));
        }

        public void CreateStepResults(string gherkinKeyword, TestStatus stepStatus, string stepdescription = null)
        {
            switch (stepStatus)
            {
                case TestStatus.Pass:
                    _scenario.CreateNode(new GherkinKeyword(gherkinKeyword), stepdescription).Pass(stepStatus.ToString());
                    break;
                case TestStatus.Fail:
                    _scenario.CreateNode(new GherkinKeyword(gherkinKeyword), stepdescription).Fail(stepStatus.ToString());
                    break;
                case TestStatus.Error:
                    _scenario.CreateNode(new GherkinKeyword(gherkinKeyword), stepdescription).Error(stepStatus.ToString());
                    break;
                case TestStatus.Inconclusive:
                    _scenario.CreateNode(new GherkinKeyword(gherkinKeyword), stepdescription).Skip(stepStatus.ToString());
                    break;
                default:
                    throw new NotSupportedException("Status not supported " + stepStatus);
            }
        }
    }
}