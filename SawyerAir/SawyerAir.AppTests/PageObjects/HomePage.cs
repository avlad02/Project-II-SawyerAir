using OpenQA.Selenium;
using SawyerAir.AppTests.PageObjects;
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

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logoutButton;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div/ul[1]/li[2]/a")]
        private IWebElement manageButton;

        [FindsBy(How = How.XPath, Using = "/html/body/header/nav/div/div/ul[2]/li[3]/a")]
        private IWebElement routesButton;

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

        public ManagePage GoToManagePage()
        {
            manageButton.Click();
            return new ManagePage(webDriver);
        }

        public RoutesPage GoToRoutesPage()
        {
            routesButton.Click();
            return new RoutesPage(webDriver);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44396/");
        }
    }
}