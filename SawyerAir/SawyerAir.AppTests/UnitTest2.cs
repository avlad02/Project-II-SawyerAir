using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SawyerAir.AppTests.PageObjects;
using SawyerAir.AutomatedTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SawyerAir.AppTests
{
    [TestClass]
    public class UnitTest2
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void ChecksBookkingAction()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("user4_test4", "P@ssword1");

            RoutesPage routesPage = homePage.GoToRoutesPage();
            routesPage.Details();
            routesPage.SeeFlights();
            routesPage.Book();
            routesPage.Pay("10/10/00202110:10AM", "card", "1", "10/10/00202110:10AM");
            routesPage.GoToPayment();
            routesPage.CardInfo("1111000011110000", "111");
            routesPage.Confirm();
            routesPage.Confirm();

        }

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    webDriver.Close();
        //}
    }
}
