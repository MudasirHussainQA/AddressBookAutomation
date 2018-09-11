using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SampleApplication1
{
    [TestClass]
    public class Tests
    {

        private IWebDriver driver { get; set; }

        internal TestUser TheTestUser { get; set; }

        //internal SampleAppPage AppPage { get; private set; }
        internal SampleApplicationPage SampleAppPage { get; private set; }

        [TestMethod]
        [TestCategory("Sample Application Tests")]
        [Description("Signing In to Application.")]
        public void SignIn_Application()
        {


            SampleAppPage.GoTo();
            SampleAppPage.FilloutandSubmit(TheTestUser);
            var db = new DashboardPage(driver);
            Assert.IsTrue(db.IsVisible, "Dashboard Page not Visible");
                       

        }

        [TestMethod]
        [TestCategory("Sample Application Tests")]
        public void TestMethod2()
        {


            SampleAppPage.GoTo();            
            SampleAppPage.FilloutandSubmit(TheTestUser);
            var db = new DashboardPage(driver);
            Assert.IsFalse(!db.IsVisible, "Dashboard Page not Visible");


        }

        [TestMethod]
        [TestCategory("Sample Application Tests")]
        [Description("Create Address Test Case.")]
        public void CreateAddress()
        {

                       
            SampleAppPage.GoTo();
            SampleAppPage.FilloutandSubmit(TheTestUser);
            Thread.Sleep(1000);
            var addresspage = new AddressPage(driver);            
            addresspage.ClickAddressLink();
            Thread.Sleep(1000);
            var newaddresspage = new NewAddress(driver);
            newaddresspage.SaveRecordwithRequiredFieldsOnly(TheTestUser);          
            


        }

        [TestMethod]
        [TestCategory("Sample Application Tests")]
        public void CreateAddresswithCountry()
        {

                       
            SampleAppPage.GoTo();
            SampleAppPage.FilloutandSubmit(TheTestUser);
            Thread.Sleep(1000);
            var addresspage = new AddressPage(driver);
            addresspage.ClickAddressLink();
            Thread.Sleep(1000);
            var newaddresspage = new NewAddress(driver);
            newaddresspage.SaveRecordwithCountry(TheTestUser);



        }





        [TestInitialize]
        public void SetupforEveryTestMethod()
        {
            driver = GetChromeDriver();
            SampleAppPage = new SampleApplicationPage(driver);
            driver.Manage().Window.Maximize();
            TheTestUser= new TestUser();
            TheTestUser.Email = "y1@yopmail.com";
            TheTestUser.Password = "123";
            TheTestUser.firstname = "User1";
            TheTestUser.lastname = "lname";
            TheTestUser.address = "bemina";
            TheTestUser.city = "srinagar";
            TheTestUser.zipcode = "190018";
            TheTestUser.selectCountry = Country.Canada;
            //TheTestUser.selectCommonIntrest = CommonIntrest.Reading;
        }

        [TestCleanup]

        public void CleanupAfterTest()
        {
            driver.Close();
            driver.Quit();
        }

        

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");            
            return option;
        }

        private static ChromeDriver GetChromeDriver1()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
    }
}
