using CMDAutomation.BDD.Factories;
using CMDReportGenerator;
using CMDReportGenerator.ConcreteClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CMDAutomation.BDD.Steps
{
    [Binding]
    public sealed class ForecastSteps
    {
        private IWebDriver _driver;
        private TestInformation _testInfo;
        private Reporter _reporter = Reporter.Report;
        public ForecastSteps(IWebDriver driver,TestInformation testInfo)
        {
            _driver = driver;
            _testInfo = testInfo;
        }

        [Given(@"expand all the filters")]
        public void GivenExpandAllTheFilters()
        {
            //Click on Clear All button to expand all the filters
            _testInfo.PageFactory.ForeCastPage.ClearAllPlusIconId.Click();
            Thread.Sleep(500);
            _reporter.CreateStepResults("Given", TestStatus.Pass, "expand all the filters");
        }

        [When(@"Data Set is '(.*)' and Measurement type is '(.*)'")]
        public void WhenDataSetIsAndMeasurementTypeIs(string dataSet, string measurementType)
        {
            //Check whether the Data Set type is selected or not
            var requiredDataSetRadioButton = DataSetTypeRadioButtonLookUp(dataSet);
            var isDataSetSelected = requiredDataSetRadioButton.GetAttribute("class").Contains("checked");
            Assert.IsTrue(isDataSetSelected, dataSet + " Data set is not selected");
            _reporter.CreateStepResults("When", TestStatus.Pass, "Data set " + dataSet + " is selected");

            //Check whether the Measurement type is selected or not
            var measurementTypeRadioButton = MeasurementTypeLookUp(measurementType);
            var isMeasurementTypeSelected = measurementTypeRadioButton.GetAttribute("class").Contains("checked");
            Assert.IsTrue(isMeasurementTypeSelected, measurementType + " Measurement type is not selected");
            _reporter.CreateStepResults("When", TestStatus.Pass, "expand all the filters");
        }

        [When(@"select '(.*)' measurement type")]
        public void WhenISelectMeasurementType(string type)
        {
            var radioButton = MeasurementTypeLookUp(type);
            var isRadioButtonChecked = radioButton.GetAttribute("class").Contains("checked");
            if (!isRadioButtonChecked)
                radioButton.Click();
            Thread.Sleep(5000); //Explicit wait
        }
        [Then(@"the following Development Types should be displayed and enabled")]
        public void ThenTheFollowingDevelopmentTypesShouldBeDisplayedAndEnabled(Table table)
        {
            var types = table.CreateSet<Filters>();
            foreach (var type in types)
            {
                var radioButton = DevelopmentTypeLookUp(type.DevelopmentType);
                Assert.IsTrue(radioButton.Displayed, type.DevelopmentType + " is not displayed");
                Assert.IsTrue(radioButton.Enabled, type.DevelopmentType + " is not enabled");
            }
        }
        [Then(@"The following Development Types should be disabled")]
        public void ThenTheFollowingDevelopmentTypesShouldBeDisabled(Table table)
        {
            var types = table.CreateSet<Filters>();
            foreach (var type in types)
            {
                var radioButton = DevelopmentTypeSpanIDLookUp(type.DevelopmentType);
                var isRadioButtonDisabled = radioButton.GetAttribute("class").Contains("disabled-element");
                Assert.IsTrue(isRadioButtonDisabled, type.DevelopmentType + " is enabled");
            }
        }
        #region Private helpers
        private IWebElement DevelopmentTypeLookUp(string type)
        {
            switch (type)
            {
                case "All":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAllRadioButton;
                case "New":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeNewRadioButton;
                case "New and Addition":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeNewAdditionRadioButton;
                case "Renovation":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeRenovationRadioButton;
                case "Addition":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAdditionRadioButton;
                case "Alteration":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAlterationRadioButton;
                case "Addition/Alteration":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAdditionAlterationRadioButton;
                default:
                    throw new NotSupportedException("Type not supported" + type);
            }
        }
        private IWebElement MeasurementTypeLookUp(string type)
        {
            switch (type)
            {
                case "Value":
                    return _testInfo.PageFactory.ForeCastPage.MeasurementValueRadioButton;
                case "Sq.Ft.":
                    return _testInfo.PageFactory.ForeCastPage.MeasurementSqFtRadioButton;
                case "Projects":
                    return _testInfo.PageFactory.ForeCastPage.MeasurementProjectsRadioButton;
                default:
                    throw new NotSupportedException("Type not supported" + type);
            }
        }
        private IWebElement DevelopmentTypeSpanIDLookUp(string type)
        {
            switch (type)
            {
                case "All":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAllRadioButtonSpanID;
                case "New":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeNewRadioButtonSpanID;
                case "New and Addition":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeNewAdditionRadioButtonSpanID;
                case "Renovation":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeRenovationRadioButtonSpanID;
                case "Addition":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAdditionRadioButtonSpanID;
                case "Alteration":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAlterationRadioButtonSpanID;
                case "Addition/Alteration":
                    return _testInfo.PageFactory.ForeCastPage.DevelopmentTypeAdditionAlterationRadioButtonSpanID;
                default:
                    throw new NotSupportedException("Type not supported" + type);
            }
        }

        private IWebElement DataSetTypeSpanIDLookUp(string type)
        {
            switch (type)
            {
                case "Historical and Forecast":
                    return _testInfo.PageFactory.ForeCastPage.DataSetTypeHistoricalForecastRadioButtonSpanID;
                case "Historical":
                    return _testInfo.PageFactory.ForeCastPage.DataSetTypeHistoricalRadioButtonSpanID;
                default:
                    throw new NotSupportedException("Type not supported" + type);
            }
        }

        private IWebElement DataSetTypeRadioButtonLookUp(string type)
        {
            switch (type)
            {
                case "Historical and Forecast":
                    return _testInfo.PageFactory.ForeCastPage.DataSetTypeHistoricalForecastRadioButtonID;
                case "Historical":
                    return _testInfo.PageFactory.ForeCastPage.DataSetTypeHistoricalRadioButtonID;
                default:
                    throw new NotSupportedException("Type not supported" + type);
            }
        }
        #endregion
    }
}
