using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace SampleApplication1
{
    internal class SampleApplicationPage : BasePage
    {



        public SampleApplicationPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsLoaded => Driver.Title.Contains(PageTitle);

        private string PageTitle => "Address Book - Sign In";

        public IWebElement EmailField => Driver.FindElement(By.CssSelector("input#session_email"));

        public IWebElement PasswordField => Driver.FindElement(By.CssSelector("input#session_password"));

        public IWebElement SignInButton => Driver.FindElement(By.CssSelector("[type = 'submit']"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://a.testaddressbook.com/sign_in");
            Assert.IsTrue(IsLoaded,
               $"Sample application page was not visible. Expected=>{PageTitle}." +
               $"Actual=>{Driver.Title}");

        }
       

        internal DashboardPage FilloutandSubmit(TestUser User)

        {
            EmailField.SendKeys(User.Email);
            PasswordField.SendKeys(User.Password);
            SignInButton.Submit();
            return new DashboardPage(Driver);
        }

    }
    }
