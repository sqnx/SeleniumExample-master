using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Structura.GuiTests.PageObjects;

namespace Tests.PageObjects
{
    public class MainMenu
    {
        private readonly IWebDriver _driver;
        private static readonly ILog log =
LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainMenu(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#menu-item-374")]
        public IWebElement registerButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#menu-item-140")]
        public IWebElement draggableButton { get; set; }

        public RegisterPage clickRegisterButton()
        {
            log.Info("Click Register Button");
            registerButton.Click();
            return new RegisterPage(_driver);
        }

        public DraggablePage clickDraggableButton()
        {
            log.Info("Click Draggable Button");
            draggableButton.Click();
            return new DraggablePage(_driver);
        }

    }
}
