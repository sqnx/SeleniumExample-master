using System.Drawing;
using System.Reflection;
using NUnit.Framework;
using Selenium.core;
using Structura.GuiTests.PageObjects;
using Tests.PageObjects;

namespace Structura.GuiTests.Tests
{
    [TestFixture]
    [Parallelizable]
    public class DraggableTest : TestBase
    {
        [Test]
        public void draggableTest()
        {
            UITest(() =>
            {
                DraggablePage draggablePage = new MainMenu(_driver).clickDraggableButton();
                Point point1 = draggablePage.getPostion();
                draggablePage.moveDraggableElement(0, 50, 50, 0);
                Point point2 = draggablePage.getPostion();
                Assert.AreEqual(point1, point2);
            });

        }
    }
}
