using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;
using SampleApplication1;
using NLog;

namespace SampleApplication1
{
    [TestClass]
    public class Tests
    {

        private IWebDriver driver { get; set; }

        internal TestUser TheTestUser { get; set; }

        public TestContext TestContext { get; set; }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        internal SampleApplicationPage SampleAppPage { get; private set; }

        [TestMethod]
        [TestProperty("Author","Mudasir Hussain")]
        [TestCategory("Sample Application Tests")]
        [Description("Signing In to Application.")]
        public void SignIn_Application()
        {


            SampleAppPage.GoTo();
            SampleAppPage.FilloutandSubmit(TheTestUser);
            var db = new DashboardPage(driver);
            AssertPageVisible(db);          
            //Assert.IsTrue(db.IsVisible, "Dashboard Page not Visible");
                       

        }

        [TestMethod]
        [TestProperty("Author", "Mudasir Hussain")]
        [TestCategory("Sample Application Tests")]
        public void TestMethod2()
        {


            SampleAppPage.GoTo();            
            SampleAppPage.FilloutandSubmit(TheTestUser);
            var db = new DashboardPage(driver);
            Assert.IsFalse(!db.IsVisible, "Dashboard Page not Visible");


        }

        [TestMethod]
        [TestProperty("Author", "Mudasir Hussain")]
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
        [TestProperty("Author", "Mudasir Hussain")]
        [TestCategory("Logging")]
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
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            driver.Manage().Window.Maximize();
            TheTestUser= new TestUser();
            TheTestUser.Email = "y1@yopmail.com";
            TheTestUser.Password = "123";
            TheTestUser.firstname = Helper.RandomString(5);
            TheTestUser.lastname = Helper.RandomString(3);
            TheTestUser.address = Helper.RandomString(5);
            TheTestUser.city = Helper.RandomString(6);
            TheTestUser.zipcode = Helper.RandomInt(6);
            TheTestUser.selectCountry = Country.Canada;
            ScreenshotTaker = new ScreenshotTaker(driver, TestContext);
            //TheTestUser.selectCommonIntrest = CommonIntrest.Reading;
        }

        [TestCleanup]

        public void CleanupAfterTest()
        {
                     
           TakeScreenshotForTestFailure();         
           
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

        private static void AssertPageVisible(DashboardPage dashboardPage)
        {
            Assert.IsTrue(dashboardPage.IsVisible, "UltimateQA home page was not visible.");
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }


    }
}
