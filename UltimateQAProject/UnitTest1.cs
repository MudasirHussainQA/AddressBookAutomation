using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Data;
using System.Threading;

namespace UltimateQAProject
{
    [TestClass]
    public class UnitTest1
    {

        
        static IWebDriver driver;
        

        [TestCategory("CaptchaTest")]
        [TestMethod]
        public void TestMethod1()
        {
            
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            driver.Manage().Window.Maximize();
            var name = driver.FindElements(By.Id("et_pb_contact_name_1"));            
            name[1].SendKeys("Mudasir");
            var message = driver.FindElements(By.Id("et_pb_contact_message_1"));           
            message[1].SendKeys("Hello");

            var captcha = driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(captcha.Text, "");
            var captchaTextBox = driver.FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());
            
            driver.FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[1].Submit();
            Thread.Sleep(2500);
            var successMessage = driver.FindElement(By.XPath("//*[@class='et-pb-contact-message']//p[contains(text(), 'Success')][1]"));
                    

            Thread.Sleep(2500);
            Assert.IsTrue(successMessage.Text.Equals("Success"));



        }

        [TestCategory("DriverInterrogation")]
        [TestMethod]
        public void DriverLevelInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            var x = driver.CurrentWindowHandle;
            var y = driver.WindowHandles;
            x = driver.PageSource;
            x = driver.Title;
            x = driver.Url;



        }

        [TestCategory("ElementInterrogation")]
        [TestMethod]

        public void ElementInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");            
            var myelement = driver.FindElement(By.XPath("//*[@href='https://courses.ultimateqa.com/users/sign_in']"));
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void ElementInterrogationTest()
        {
            driver.Url = "https://www.ultimateqa.com/simple-html-elements-for-automation/";
            driver.Manage().Window.Maximize();    
                                        
            var myElement = driver.FindElement(By.Id("button1"));
            Assert.AreEqual("submit", myElement.GetAttribute("type"));
            Assert.AreEqual("normal", myElement.GetCssValue("letter-spacing"));
            Assert.IsTrue(myElement.Displayed);
            Assert.IsTrue(myElement.Enabled);
            Assert.IsFalse(myElement.Selected);
            Assert.AreEqual(myElement.Text, "Click Me!");
            Assert.AreEqual("button", myElement.TagName);
            Assert.AreEqual(21, myElement.Size.Height);
            Assert.AreEqual(190, myElement.Location.X);
            Assert.AreEqual(255, myElement.Location.Y);
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigationTest()
        {
            //Go here and assert for title - "https://www.ultimateqa.com"
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            Assert.AreEqual("Home - Ultimate QA", driver.Title);
            //Go here and assert for title - "https://www.ultimateqa.com/automation"
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation");
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
            //Click link with href - /complicated-page
            driver.FindElement(By.XPath("//*[@href='/complicated-page']")).Click();
            //assert page title 'Complicated Page - Ultimate QA'
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);
            //Go back
            driver.Navigate().Back();
            //assert page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
        }



        [TestInitialize]
       
        public void TestSetUp()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects");
            driver = new ChromeDriver(@"C:\Projects");
            
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
