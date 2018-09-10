using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication1
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
