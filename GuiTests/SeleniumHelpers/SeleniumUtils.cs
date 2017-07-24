using OpenQA.Selenium;
using Selenium.core;

namespace Structura.GuiTests.SeleniumHelpers
{
    public class SeleniumUtils : TestBase
    {
        public SeleniumUtils(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                log.Error(e);
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            var alert = _driver.SwitchTo().Alert();
            alert.Accept();
            return alert.Text;
        }
    }
}

