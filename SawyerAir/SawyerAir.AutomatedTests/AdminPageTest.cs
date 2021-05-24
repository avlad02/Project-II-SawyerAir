using SawyerAir.AutomatedTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            addStopPage.Save("My Test Stop Name");

            LogoutPage logoutPage = homePage.GoToLogoutPage();
            logoutPage.Logout();

        }

        [TestMethod]
        public void ChecksLineCreated()
        {
            Random randomNumber = new Random();
            string StopName = "MyTestLine " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("Beth_A13", "Password1.");

            AdminPage indexPage = new AdminPage(webDriver);
            indexPage.GoToPage();
            AddLinePage addLinePage = indexPage.GotoAddLinePage();
            addLinePage.Save("My Test Line Name");

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
