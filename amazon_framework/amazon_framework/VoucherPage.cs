using System;
using OpenQA.Selenium;

namespace amazon_framework
{
    internal class VoucherPage : BasePage
    {
        
        public VoucherPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        { get
            {
                try
                {
                    return Driver.FindElement(By.Id("merchandised-content")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

             }
        }

            

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.co.uk/vouchers-coupons/b/?_encoding=UTF8&node=5522783031&ref_=nav_cs_coupons");
        }
    }
}