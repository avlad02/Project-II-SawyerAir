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
    class LinesIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement linesList;


        public LinesIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44396/Lines");
        }


        public bool LineExists(string LineName)
        {
            var elements = linesList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(LineName)).Count() > 0;
        }

        public bool CheckIfLineIsPresent(string LineName)
        {
            var elements = linesList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(LineName)).Count() == 0;
        }
    }
}
