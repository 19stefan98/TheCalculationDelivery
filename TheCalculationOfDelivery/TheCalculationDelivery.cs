using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TheCalculationOfDelivery
{
    class TheCalculationDelivery
    {
        public IWebDriver driver { get; set; }
        public string text { get; set; }
        TimeSpan timeout = new TimeSpan(00, 00, 15);

        public TheCalculationDelivery(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://bolshoy.itech-test.ru/payment-and-delivery/");

            Actions actions = new Actions(driver);

            var country = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("label")));
            actions.MoveToElement(country[1]).Click().Build().Perform();

            var scroll= (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("selectric-scroll")));
            actions.MoveToElement(scroll[1]).SendKeys("Росс" + Keys.Enter).Build().Perform();

            var city = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("DHL[CITY_TO]")));
            city.SendKeys("Ульяновск");
            var index=(new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("DHL[ZIP_CODE_TO]")));
            index.SendKeys("432000");
            var weight= (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("DHL[WEIGHT]")));
            weight.SendKeys("100");
            weight.Submit();
            text= (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("no-mar"))).Text;
        }
    }
}
