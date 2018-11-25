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
            var successMessage = driver.FindElements(By.ClassName("et-pb-contact-message"))[1].FindElement(By.TagName("p"));
            Thread.Sleep(2500);
            Assert.IsTrue(successMessage.Text.Equals("Success"));



        }

        [TestInitialize]
       
        public void TestSetUp()
        {

            var outputDirectory = Path.GetDirectoryName(@"C:\Projects");
            driver = new ChromeDriver(@"C:\Projects");
            
        }
    }
}
