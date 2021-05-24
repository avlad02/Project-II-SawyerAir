using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SawyerAir.AutomatedTests
{
    [TestClass]
    public class AdminPageTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }



        [TestCleanup]
        public void Cleanup()
        {
           driver.Close();
        }
    }
}
