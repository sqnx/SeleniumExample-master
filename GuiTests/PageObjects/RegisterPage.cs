using System;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Selenium.core;
using Structura.GuiTests.Obects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private static readonly ILog log =
LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#name_3_firstname")]
        public IWebElement firstNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#name_3_lastname")]
        public IWebElement lastNameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#phone_9")]
        public IWebElement phoneNumberInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#username")]
        public IWebElement usernameInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#email_1")]
        public IWebElement emailInput { get; set; }

        public void setFirstName(string firstName)
        {
            log.Info("Set first name to " + firstName);
            firstNameInput.SendKeys(firstName);
        }
        public void setLastName(string lastName)
        {
            log.Info("Set last name to " + lastName);
            lastNameInput.SendKeys(lastName);
        }
        public void setPhoneNumber(string phoneNumber)
        {
            log.Info("Set phone number to " + phoneNumber);
            phoneNumberInput.SendKeys(phoneNumber);
        }
        public void setUsername(string username)
        {
            log.Info("Set username to " + username);
            usernameInput.SendKeys(username);
        }
        public void setEmail(string email)
        {
            log.Info("Set email to " + email);
            emailInput.SendKeys(email);
        }

        public void registerUser(UserObjects user)
        {
            if (!String.IsNullOrEmpty(user.getFirstName())) {
                setFirstName(user.getFirstName());
            }
            if (!String.IsNullOrEmpty(user.getLastName()))
            {
                setLastName(user.getLastName());
            }
            if (!String.IsNullOrEmpty(user.getPhoneNumber()))
            {
                setPhoneNumber(user.getPhoneNumber());
            }
        }

    }
}
