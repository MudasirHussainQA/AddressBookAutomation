using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace AdressTests
{
    [TestClass]
    public class ElementIdent
    {
        static IWebDriver driver;
        private IWebElement element;
        private By locator;


        [TestInitialize]
        public void TestSetup()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outputDirectory);

        }

        [TestMethod]
        [TestCategory("Identification of Website")]
        public void TestMethod1()
        {

            driver.Navigate().GoToUrl("http://a.testaddressbook.com/sign_in");

        }
    }
}
