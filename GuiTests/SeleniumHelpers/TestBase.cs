using System;
using System.Diagnostics;
using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;

namespace Selenium.core
{
    [SetUpFixture]
    public class TestBase
    {
        public IWebDriver _driver = new DriverFactory().Create();
        public string _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
        public static ILog log =
    LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        DateTime date = DateTime.Now;
        Stopwatch _stopWatch = Stopwatch.StartNew();


        [SetUp]
        public void OneTimeSetUp()
        {
            log.Info("TEST: " + TestContext.CurrentContext.Test.FullName);
            log.Info("BROWSER: " + ConfigurationHelper.Get<String>("DriverToUse"));
            log.Info("URL: " + _baseUrl);
            _driver.Navigate().GoToUrl(_baseUrl);
            
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            try
            {
                log.Info("************************** TEST FINISHED **************************");
                log.Info("STATUS: " + TestContext.CurrentContext.Result.Outcome);
                log.Info("TEST NAME: " + TestContext.CurrentContext.Test.Name);
                log.Info("TEST CLASS: " + TestContext.CurrentContext.Test.ClassName);
                log.Info("TEST TIME: " + _stopWatch.Elapsed);
                log.Info("CLOSING BROWSER: " + ConfigurationHelper.Get<String>("DriverToUse"));
                _driver.Close();
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                log.Error(Environment.NewLine + "****************** FOUND EXCEPTION ******************" + Environment.NewLine + ex + Environment.NewLine);
                var screenshot = _driver.TakeScreenshot();
                screenshot.SaveAsFile(@"D:\TEMP\" 
                                    + date.ToString("yyyy-MM-dd_HH.mm.ss") 
                                    + "_"
                                    + TestContext.CurrentContext.Test.FullName
                                    + ".png", ScreenshotImageFormat.Png);
                throw;
            }
        }

    }
}