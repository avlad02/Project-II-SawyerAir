using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawyerAir.AutomatedTests.PageObjects
{
    class HomePage
    {
        private IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement loginButton;

        [FindsBy(How = How.LinkText, Using = "Administration")]
        private IWebElement adminButton;

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logoutButton;

        public LoginPage GoToLoginPage()
        {
            loginButton.Click();
            return new LoginPage(webDriver);
        }
        public LogoutPage GoToLogoutPage()
        {
            logoutButton.Click();
            return new LogoutPage(webDriver);
        }
        public AdminPage GoToAdminPage()
        {
            adminButton.Click();
            return new AdminPage(webDriver);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44396/");
        }
    }
}
