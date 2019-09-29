using System;
using OpenQA.Selenium;

namespace amazon_framework
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.co.uk");
        }

        internal SearchPage Search(string itemToSearchFor)
        {
            Driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(itemToSearchFor);
            Driver.FindElement(By.XPath("//input[@value='Go']")).Click();
            return new SearchPage(Driver);
        }
    }
}