using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApplication1
{
    public class AddressPage : BasePage
    {
        public AddressPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement AddressLink => Driver.FindElement(By.LinkText("Addresses"));
   
       public IWebElement NewAddressfield => Driver.FindElement(By.XPath("/html//a[@href='/addresses/new']"));

        public IWebElement IsAddressVisible => Driver.FindElement(By.TagName("h2"));

        internal AddressPage ClickAddressLink()

        {
            Thread.Sleep(1500);
            AddressLink.Click();
            Thread.Sleep(1500);
            NewAddressfield.Click();
            
            return new AddressPage(Driver);
        }









    }
}
