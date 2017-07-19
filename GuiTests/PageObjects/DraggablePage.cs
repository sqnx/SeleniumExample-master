using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Structura.GuiTests.PageObjects
{
    public class DraggablePage
    {
        private readonly IWebDriver _driver;
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DraggablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
//
//        [FindsBy(How = How.CssSelector, Using = "#name_3_firstname")]
//        public IWebElement firstNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#draggable")]
        public IWebElement DraggablElement { get; set; }

        public Point getPostion()
        {
            log.Info("Postion of element is: " + DraggablElement.Location);
            return DraggablElement.Location;
        }

        public void moveDraggableElement(int up, int right, int down, int left)
        {
            Actions actions = new Actions(_driver);
            actions.DragAndDropToOffset(DraggablElement, DraggablElement.Location.X + right - left,
                DraggablElement.Location.Y + up - down).Build().Perform();
        }

    }
}
