using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace testing_framework
{
    internal class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver){}

        public bool IsVisible => Driver.Title.Contains(PageTitle);
        private string PageTitle => "Registration";

        public IWebElement UsernameField => Driver.FindElement(By.Id("inputUsername"));

        public IWebElement FirstNameField => Driver.FindElement(By.Id("inputFirstname"));

        public IWebElement LastNameField => Driver.FindElement(By.Id("inputLastname"));

        public IWebElement PasswordField => Driver.FindElement(By.Id("inputPassword"));

        public IWebElement EmailField => Driver.FindElement(By.Id("inputEmail"));

        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@value='female']"));

        public IWebElement RegisterButton => Driver.FindElement(By.ClassName("btn"));

       

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://localhost/dt/reg.php");
            Assert.IsTrue(IsVisible,
                $"Registration page was not visible. Expected =>{PageTitle}." +
                $"Actual=>{Driver.Title}");

                //Assert.IsTrue(RegPage.IsVisible, "Registration page was not visible.");
        }

        internal HomePage FillOutFormAndSubmit(TestRegUser user)
        {
            UsernameField.SendKeys(user.Username);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            PasswordField.SendKeys(user.Password);
            EmailField.SendKeys(user.Email);
            SetGender(user);
            RegisterButton.Submit();

            Driver.Navigate().Back();
            Driver.FindElement(By.XPath("//img[contains(@src,'pictures/logo_navbar.png')]")).Click();

            return new HomePage(Driver);
        }

        private void SetGender(TestRegUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
    }
}

//Driver.Navigate().Back();
//Driver.FindElement(By.XPath("//img[contains(@src,'pictures/logo_navbar.png')]")).Click();