using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;

namespace Selenium.core
{
    [SetUpFixture]
    public class TestBase
    {
        public IWebDriver _driver = new DriverFactory().Create();
        public string _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
        public static readonly ILog log =
    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            log.Info("OPENING BROWSER: " + ConfigurationHelper.Get<String>("DriverToUse"));
           // _driver = new DriverFactory().Create();
            log.Info("OPENING URL: " + ConfigurationHelper.Get<String>("TargetUrl"));
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }

        }
    }
}