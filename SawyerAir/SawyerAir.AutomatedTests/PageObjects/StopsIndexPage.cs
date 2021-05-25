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
    class StopsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement stopsList;


        public StopsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44396/Stops");
        }


        public bool StopExists(string stopName)
        {
            var elements = stopsList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(stopName)).Count() > 0;
        }

        public bool CheckIfStationIsPresent(string stopName)
        {
            var elements = stopsList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(stopName)).Count() == 0;
        }
    }
}
