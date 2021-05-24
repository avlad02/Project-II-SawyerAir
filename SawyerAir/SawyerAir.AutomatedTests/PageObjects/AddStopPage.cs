using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawyerAir.AutomatedTests.PageObjects
{
    class AddStopPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "StopLocation")]
        private IWebElement stopLocationTextBox;


        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[2]/input")]
        private IWebElement createButton;
        public AddStopPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string StopName)
        {
            this.stopLocationTextBox.Clear();
            this.stopLocationTextBox.SendKeys(StopName);
            createButton.Click();
        }
    }
}
