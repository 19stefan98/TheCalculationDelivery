using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TheCalculationOfDelivery
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Delivery()
        {
            string actual = "1003 рублей";
            TheCalculationDelivery del = new TheCalculationDelivery(driver);
            del.Action();
            Assert.AreEqual(del.text, actual);
        }
    }
}