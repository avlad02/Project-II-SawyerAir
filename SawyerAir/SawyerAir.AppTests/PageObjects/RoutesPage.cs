using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SawyerAir.AppTests.PageObjects
{
    class RoutesPage
    {
        private IWebDriver webDriver;

        //go to details
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table/tbody/tr/td[3]/b/a")]
        private IWebElement detailsLink;

        public void Details()
        {
            detailsLink.Click();
        }

        //see flights
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[2]/a[2]")]
        private IWebElement seeFlightsLink;

        public void SeeFlights()
        {
            seeFlightsLink.Click();
        }

        //book
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/table/tbody/tr/td[4]/a")]
        private IWebElement bookButton;

        public void Book()
        {
            bookButton.Click();
        }

        //booking page 
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[3]/input")]
        private IWebElement paymentDateTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[4]/input")]
        private IWebElement paymentMethodTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[5]/input")]
        private IWebElement flightClassTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[6]/input")]
        private IWebElement bookingDateTextBox;

        public void Pay(string paymentDateTime, string card, string flightClass, string bookingDateTime)
        {
            paymentDateTextBox.Clear();
            paymentDateTextBox.SendKeys(paymentDateTime);
            paymentMethodTextBox.Clear();
            paymentMethodTextBox.SendKeys(card);
            flightClassTextBox.Clear();
            flightClassTextBox.SendKeys(flightClass);
            bookingDateTextBox.Clear();
            bookingDateTextBox.SendKeys(bookingDateTime);
        }

        //go to payment
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[7]/input")]
        private IWebElement goToPaymentButton;

        public void GoToPayment()
        {
            goToPaymentButton.Click();
        }

        //card page
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[3]/input")]
        private IWebElement cardNumberTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[4]/input")]
        private IWebElement CVCTextBox;

        public void CardInfo(string cardNumber, string CVC)
        {
            cardNumberTextBox.Clear();
            cardNumberTextBox.SendKeys(cardNumber);
            CVCTextBox.Clear();
            CVCTextBox.SendKeys(CVC);
        }

        //confirm payment
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/form/div[5]/input")]
        private IWebElement confirmButton;

        public void Confirm()
        {
            confirmButton.Click();
        }

        public RoutesPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
