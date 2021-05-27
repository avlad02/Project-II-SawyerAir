using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace SawyerAir.AppTests.PageObjects
{
    class ManagePage
    {
        private IWebDriver webDriver;

        //profile
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[1]/ul/li[1]/a")]
        private IWebElement profileButton;

        //profile info
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div[1]/div/form/div[1]/input")]
        private IWebElement inputNameTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div[1]/div/form/div[2]/input")]
        private IWebElement inputFirstNameTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div[1]/div/form/div[3]/input")]
        private IWebElement inputPhoneTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div[1]/div/form/div[4]/input")]
        private IWebElement inputAddressTextBox;

        //save button
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div[1]/div/form/button")]
        private IWebElement saveChangesButton;

        public void Profile()
        {
            profileButton.Click();
        }

        public void ProfileInfo(string Name, string FirstName, string Phone, string Address)
        {
            inputNameTextBox.Clear();
            inputNameTextBox.SendKeys(Name);
            inputFirstNameTextBox.Clear();
            inputFirstNameTextBox.SendKeys(FirstName);
            inputPhoneTextBox.Clear();
            inputPhoneTextBox.SendKeys(Phone);
            inputAddressTextBox.Clear();
            inputAddressTextBox.SendKeys(Address);
        }

        public void SaveProfileChanges()
        {
            saveChangesButton.Click();
        }


        //email
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[1]/ul/li[2]/a")]
        private IWebElement emailButton;

        public void Email()
        {
            emailButton.Click();
        }

        //email info
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/div[3]/input")]
        private IWebElement changeEmailTextBox;

        public void EmailInfo(string newEmail)
        {
            changeEmailTextBox.Clear();
            changeEmailTextBox.SendKeys(newEmail);
        }

        //save changes
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/button")]
        private IWebElement saveEmailChanges;

        public void SaveEmailChanges()
        {
            saveEmailChanges.Click();
        }

        //password
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[1]/ul/li[3]/a")]
        private IWebElement passwordButton;

        public void Password()
        {
            passwordButton.Click();
        }

        //password info
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/div[2]/input")]
        private IWebElement oldPassTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/div[3]/input")]
        private IWebElement newPassTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/div[4]/input")]
        private IWebElement confirmPassTextBox;

        public void NewPassInfo(string oldPass, string newPass, string confirmNewPass)
        {
            oldPassTextBox.Clear();
            oldPassTextBox.SendKeys(oldPass);
            newPassTextBox.Clear();
            newPassTextBox.SendKeys(newPass);
            confirmPassTextBox.Clear();
            confirmPassTextBox.SendKeys(confirmNewPass);
        }

        //update new password
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div[2]/div/div/form/button")]
        private IWebElement updatePassButton;

        public void UpdatePassword()
        {
            updatePassButton.Click();
        }

        public ManagePage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
