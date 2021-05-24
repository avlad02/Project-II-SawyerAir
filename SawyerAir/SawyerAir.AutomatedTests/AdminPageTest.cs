using SawyerAir.AutomatedTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using SawyerAir.AutomatedTests.PageObjects;
using System;

namespace SawyerAir.AutomatedTests
{
    [TestClass]
    public class AdminPageTest
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void ChecksStopCreated()
        {
            Random randomNumber = new Random();
            string StopName = "MyTestStop " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("Beth_A13", "Password1.");

            AdminPage indexPage = new AdminPage(webDriver);
            indexPage.GoToPage();
            AddStopPage addStopPage = indexPage.GotoAddStopPage();
            addStopPage.Save(StopName);

            LogoutPage logoutPage = homePage.GoToLogoutPage();
            logoutPage.Logout();

        }

        [TestMethod]
        public void ChecksLineCreated()
        {
            Random randomNumber = new Random();
            string LineName = "MyTestLine " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("Beth_A13", "Password1.");

            AdminPage indexPage = new AdminPage(webDriver);
            indexPage.GoToPage();
            AddLinePage addLinePage = indexPage.GotoAddLinePage();
            addLinePage.Save(LineName);

            LogoutPage logoutPage = homePage.GoToLogoutPage();
            logoutPage.Logout();

        }


        [TestCleanup]
        public void Cleanup()
        {
           webDriver.Close();
        }
    }
}
