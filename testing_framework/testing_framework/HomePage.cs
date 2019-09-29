using System;
using OpenQA.Selenium;

namespace testing_framework
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver){}
        
        public bool IsVisible
        {
            get
            {
                try
                {
                    return Driver.Title.Contains("Dream Travel");
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

            }

        }

        

        //internal void GoToHomePage()
        //{
            //Driver.Navigate().GoToUrl("http://localhost/dt/index.php");
        //}

        //public bool IsVisible2 => Driver.Title.Contains("Dream Travel");

    }
}