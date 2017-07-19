using NUnit.Framework;
using Selenium.core;
using Structura.GuiTests.Obects;
using Tests.PageObjects;

namespace Structura.GuiTests
{
    [TestFixture]                                                                                                                   
    [Parallelizable]
    public class RegisterTest : TestBase
    {
        [Test]
        public void registerUser()
        {
            UserObjects user = new UserObjects("firstName", "lastName", "111222");
            new MainMenu(_driver).clickRegisterButton().registerUser(user);
        }
    }
}
