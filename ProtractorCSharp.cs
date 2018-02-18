using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Protractor;
using OpenQA.Selenium.Chrome;

namespace ProtractorCSharp
{
    [TestClass]
    public class ProtractorCSharp
    {
        private static IWebDriver Driver;
        private static NgWebDriver ngDriver;
        private static String base_url = "https://softwaretestingblog.com";

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(40);
            ngDriver = new NgWebDriver(Driver);
            ngDriver.IgnoreSynchronization = true;

            Driver.Navigate().GoToUrl(base_url);
            ngDriver.Url = Driver.Url;
        }

        [TestMethod]
        public void ProtractorTestUsingCSharp()
        {
            ngDriver.FindElement(NgBy.Binding("BindingName")).Click();
            ngDriver.FindElement(NgBy.Model("ModelName")).SendKeys("Text");
            ngDriver.FindElement(NgBy.Repeater("Value")).Click();
            ngDriver.FindElement(NgBy.SelectedOption("Options")).Click();
            ngDriver.FindElement(By.ClassName("ClassName")).SendKeys("Text");
            ngDriver.FindElement(By.TagName("Tag")).Click();
            ngDriver.FindElement(By.CssSelector("#CssSelector")).Click();
            ngDriver.FindElement(By.Id("Id")).Click();
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            ngDriver.Close();
            ngDriver.Quit();
        }
    }
}