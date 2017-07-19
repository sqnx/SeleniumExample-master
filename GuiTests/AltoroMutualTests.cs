using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.core;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;

namespace Structura.GuiTests
{
    [TestFixture]
    public class AltoroMutualTests : TestBase
    {
        private StringBuilder _verificationErrors;
        private string _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");



        [Test]
        public void LoginWithValidCredentialsShouldSucceed()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);
            log.Info("sasd");

            // Assert
            new MainPage(_driver).GetAccountButton.Displayed.Should().BeTrue();
        }

        [Test]
        public void LoginWithInvalidCredentialsShouldFail()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsNobody(_baseUrl);

            // Assert
            Action a = () =>
            {
                var displayed = new MainPage(_driver).GetAccountButton.Displayed; // throws exception if not found
            };
            a.ShouldThrow<NoSuchElementException>().WithMessage("Could not find element by: By.Id: btnGetAccount");
        }
        
        [Test]
        public void TransferAmountShouldBeAccepted()
        {
            // Arrange
            new LoginPage(_driver).LoginAsAdmin(_baseUrl);
            var transferFundsPage = new TransferFundsPage(_driver);
            new MainPage(_driver).NavigateToTransferFunds();

            // Act
            transferFundsPage.Transfer99Dollar();

            // Assert

            // Need to wait until the results are displayed on the web page
            Thread.Sleep(1000);
            
            transferFundsPage.TranferMoneyMessage.Text.StartsWith(
                "$99 was successfully transferred from Account 20 into Account 21"
                , true, CultureInfo.InvariantCulture).Should().BeTrue();
        }
    }
}


