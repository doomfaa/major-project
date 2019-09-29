using System;
using OpenQA.Selenium;

namespace amazon_framework
{
    internal class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal bool Contains(Item itemToCheckFor)
        {
            switch (itemToCheckFor)
            {
                case Item.WorkDress:
                    return driver.FindElement(By.LinkText("Long Sleeve")).Displayed;
                default:
                    throw new ArgumentOutOfRangeException("No such item exists");
            }
        }
    }
}