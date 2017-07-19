using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            DraggablePage draggablePage = new MainMenu(_driver).clickDraggableButton();
            Point point1 = draggablePage.getPostion();
            draggablePage.moveDraggableElement(0, 50, 50, 0);
            Point point2 = draggablePage.getPostion();
            Assert.AreNotEqual(point1, point2);
        }
    }
}
