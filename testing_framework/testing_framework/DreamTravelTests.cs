using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testing_framework
{
    [TestClass]
    [TestCategory("DreamTravelApplication")]
    public class RegistrationTests
    { 
        private IWebDriver Driver { get; set; }
        internal RegistrationPage RegPage { get; private set; }
        internal TestRegUser TheTestRegUser { get; private set; }

        [TestMethod]
        [Description("Validate that user is able to fill out the form successfully using valid data.")]
        public void Test1()
        {
            TheTestRegUser.GenderType = Gender.Female;
            RegPage.GoTo();
            //Assert.IsTrue(RegPage.IsVisible, "Registration page was not visible.");
            var homePage = RegPage.FillOutFormAndSubmit(TheTestRegUser);
            AssertPageVisible(homePage);
        }

        [TestMethod]
        [Description("Validate that when selecting Male gender type the form is submited successfully.")]
        public void Test2()
        {
            TheTestRegUser.GenderType = Gender.Male;
            RegPage.GoTo();
            //Assert.IsTrue(RegPage.IsVisible, "Registration page was not visible.");
            var homePage = RegPage.FillOutFormAndSubmit(TheTestRegUser);
            AssertPageVisible(homePage);
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestInitialize]
        public void SetupBeforeEveryTest()
        {
            Driver = GetChromeDriver();
            RegPage = new RegistrationPage(Driver);

            TheTestRegUser = new TestRegUser();
            TheTestRegUser.Username = "testusername";
            TheTestRegUser.FirstName = "Test FirstName";
            TheTestRegUser.LastName = "Test Last Name";
            TheTestRegUser.Password = "Password123";
            TheTestRegUser.Email = "testemail@gmail.com";
        }

        [TestCleanup]
        public void CleanupAfterEveryTest()
        {
            Driver.Close();
            Driver.Quit();
        }

        private static void AssertPageVisible(HomePage homePage)
        {
            Assert.IsTrue(homePage.IsVisible, "Home page was not visible.");
        }
    }

    [TestClass]
    [TestCategory("DreamTravelApplication")]
    public class LoginTests
    {
        private IWebDriver Driver { get; set; }

        internal TestLoginUser TheTestLoginUser { get; private set; }

        [TestMethod]
        public void Test3()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();

            var homePage = loginPage.FillOutFormAndLogin(TheTestLoginUser);
            AssertPageVisible(homePage);
        }

        [TestMethod]
        public void Test4()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.GoTo();

            var homePage = loginPage.FillOutFormAndLogin(TheTestLoginUser);
            Assert.IsFalse(!homePage.IsVisible, "Home page was not visible.");
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestInitialize]
        public void SetUpForEverySingleTestMethod()
        {
            Driver = GetChromeDriver();
            TheTestLoginUser = new TestLoginUser();
            TheTestLoginUser.Username = "testusername";
            TheTestLoginUser.Password = "Password123";
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }

        private static void AssertPageVisible(HomePage homePage)
        {
            Assert.IsTrue(homePage.IsVisible, "Home page was not visible.");
        }
    }
}
