using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SawyerAir.AutomatedTests.PageObjects
{
    class LogoutPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/header/form/button")]
        private IWebElement logoutButton;


        public LogoutPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Logout()
        {
            logoutButton.Click();
        }
    }

}
