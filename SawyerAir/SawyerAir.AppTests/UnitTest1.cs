using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SawyerAir.AppTests.PageObjects;
using SawyerAir.AutomatedTests.PageObjects;
using System;

namespace SawyerAir.AppTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void ChecksProfileChanges()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("user4_test4", "P@ssword1");

            ManagePage managePage = homePage.GoToManagePage();
            managePage.Profile();
            managePage.ProfileInfo("user4", "test4", "0011001100", "newAddress");
            managePage.SaveProfileChanges();


            managePage.Email();
            managePage.EmailInfo("userTest99@gmail.com");
            managePage.SaveEmailChanges();

            managePage.Password();
            managePage.NewPassInfo("P@ssword1", "P@ssword1", "P@ssword1");
            managePage.UpdatePassword();

            

        }
        
        
        //[TestCleanup]
        //public void Cleanup()
        //{
        //    webDriver.Close();
        //}
    }
}
