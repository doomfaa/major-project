using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace testing_framework
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver){}

        //public bool IsVisible2 => Driver.Title.Contains("Dream Travel");

        public bool IsVisible => Driver.Title.Contains(PageTitle);
        private string PageTitle => "Log in";


        public IWebElement UsernameField => Driver.FindElement(By.Id("inputUsername"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("inputPassword"));

        public IWebElement LoginButton => Driver.FindElement(By.ClassName("btn"));


        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://localhost/dt/login.php");
            Assert.IsTrue(IsVisible,
                $"Login page was not visible. Expected =>{PageTitle}." +
                $"Actual=>{Driver.Title}");
        }

        internal HomePage FillOutFormAndLogin(TestLoginUser user)
        {
            UsernameField.SendKeys(user.Username);
            PasswordField.SendKeys(user.Password);
            LoginButton.Submit();

            return new HomePage(Driver);
        }
    }
}