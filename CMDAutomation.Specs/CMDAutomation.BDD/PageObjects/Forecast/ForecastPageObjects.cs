using OpenQA.Selenium;

namespace CMDAutomation.BDD.PageObjects.Forecast
{
    public class ForecastPageObjects
    {
        private readonly IWebDriver _driver;
        public ForecastPageObjects(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ClearAllPlusIconId
        {
            get { return _driver.FindElement(By.Id("allFiltersPlusIcon")); }
        }

        public IWebElement MeasurementValueRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonMeasurementValueID)); }
        }

        public IWebElement MeasurementSqFtRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonMeasurementSqFtID)); }
        }

        public IWebElement MeasurementProjectsRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonMeasurementProjectsID)); }
        }

        public IWebElement DevelopmentTypeAllRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeAllID)); }
        }

        public IWebElement DevelopmentTypeNewRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeNewID)); }
        }

        public IWebElement DevelopmentTypeAdditionRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeAdditionID)); }
        }

        public IWebElement DevelopmentTypeAlterationRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeAlterationID)); }
        }

        public IWebElement DevelopmentTypeAdditionAlterationRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeAdditionAlterationID)); }
        }

        public IWebElement DevelopmentTypeRenovationRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeRenovationID)); }
        }

        public IWebElement DevelopmentTypeNewAdditionRadioButton
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDevTypeNewAdditionID)); }
        }

        public IWebElement DevelopmentTypeAllRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeAllID)); }
        }

        public IWebElement DevelopmentTypeNewRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeNewID)); }
        }

        public IWebElement DevelopmentTypeAdditionRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeAdditionID)); }
        }

        public IWebElement DevelopmentTypeAlterationRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeAlterationID)); }
        }

        public IWebElement DevelopmentTypeAdditionAlterationRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeAdditionAlterationID)); }
        }

        public IWebElement DevelopmentTypeNewAdditionRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeNewAdditionID)); }
        }

        public IWebElement DevelopmentTypeRenovationRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDevTypeRenovationID)); }
        }

        #region Dataset type objects
        public IWebElement DataSetTypeHistoricalRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDataSetHistoricalID)); }
        }
        public IWebElement DataSetTypeHistoricalForecastRadioButtonSpanID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.Span_RadioButtonDataSetHistoricalForecastID)); }
        }
        public IWebElement DataSetTypeHistoricalRadioButtonID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDataSetHistoricalID)); }
        }
        public IWebElement DataSetTypeHistoricalForecastRadioButtonID
        {
            get { return _driver.FindElement(By.Id(CMDObjectRepository.Forecast.Forecast.RadioButtonDataSetHistoricalForecastID)); }
        }
        #endregion
    }
}