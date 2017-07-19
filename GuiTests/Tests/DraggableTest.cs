using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            DraggablePage draggablePage = new MainMenu(_driver).clickDraggableButton();
            draggablePage.getPostion();
            draggablePage.moveDraggableElement(0, 50, 50, 0);
            draggablePage.getPostion();
        }
    }
}
