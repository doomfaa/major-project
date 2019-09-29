using System;
using System.IO;
using System.Reflection;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace amazon_framework
{
    [TestClass]
    [TestCategory("SearchingFeature"), TestCategory("Amazon")]
    public class SearchFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Checking that if we search for browser, that browser comes back.")]
        public void TestNumber1()
        {
            string stringToSearch = "working dress";

            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search("work dress");
            Assert.IsTrue(searchPage.Contains(Item.WorkDress),
                $"When searching for the string=>{stringToSearch}, " +
                $"we did not find it in the search results.");
        }


    }

    [TestClass]
    [TestCategory("ValidateVoucherPage"), TestCategory("Amazon")]
    public class VoucherPageValidation : BaseTest
    {
        [TestMethod]
        [Description("Validate that voucher page opens successfully.")]
        public void TestNumber2()
        {
            VoucherPage voucherPage = new VoucherPage(Driver);
            voucherPage.GoTo();
            Assert.IsTrue(voucherPage.IsLoaded,
            "The voucher page did not open successfully.");
        }
    }


}

