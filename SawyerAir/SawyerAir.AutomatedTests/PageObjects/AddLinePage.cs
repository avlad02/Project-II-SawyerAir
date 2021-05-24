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
    class AddLinePage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement LineNameTextBox;


        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[2]/input")]
        private IWebElement createButton;
        public AddLinePage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string LineName)
        {
            this.LineNameTextBox.Clear();
            this.LineNameTextBox.SendKeys(LineName);
            createButton.Click();
        }
    }
}
