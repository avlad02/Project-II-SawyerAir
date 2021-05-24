using OpenQA.Selenium;
using SawyerAir.AutomatedTests.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawyerAir.AutomatedTests.PageObjects
{
    class AdminPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/a[6]")]
        private IWebElement addStopButton;

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44396/Home/Admin");
        }
        public AddStopPage GotoAddStopPage()
        {
            addStopButton.Click();
            return new AddStopPage(webDriver);
        }
        public AdminPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
