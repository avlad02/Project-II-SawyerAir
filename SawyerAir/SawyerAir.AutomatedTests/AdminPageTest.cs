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

            AdminPage adminPage = new AdminPage(webDriver);
            adminPage.GoToPage();
            AddStopPage addStopPage = adminPage.GotoAddStopPage();
            addStopPage.Save(StopName);

            StopsIndexPage indexStopsPage = new StopsIndexPage(webDriver);
            indexStopsPage.GoToPage();

            Assert.IsTrue(indexStopsPage.StopExists(StopName));

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

            AdminPage adminPage = new AdminPage(webDriver);
            adminPage.GoToPage();
            AddLinePage addLinePage = adminPage.GotoAddLinePage();
            addLinePage.Save(LineName);

            LinesIndexPage indexLinesPage = new LinesIndexPage(webDriver);
            indexLinesPage.GoToPage();

            Assert.IsTrue(indexLinesPage.LineExists(LineName));

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
