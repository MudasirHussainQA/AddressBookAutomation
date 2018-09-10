using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NLog;

namespace SampleApplication1
{
    public class NewAddress : BasePage
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public IWebElement CanadaRadioButton => Driver.FindElement(By.CssSelector("#new_address .row:nth-child(10) [type='radio']:nth-child(4)"));

        public IWebElement FirstName => Driver.FindElement(By.CssSelector("input#address_first_name"));

        public IWebElement LastName => Driver.FindElement(By.CssSelector("input#address_last_name"));

        public IWebElement Address1 => Driver.FindElement(By.CssSelector("input#address_street_address"));

        public IWebElement City => Driver.FindElement(By.CssSelector("input#address_city"));

        public IWebElement ZipCode => Driver.FindElement(By.CssSelector("input#address_zip_code"));

        public IWebElement CreateAddress => Driver.FindElement(By.CssSelector("[type='submit']"));
        

        


        public NewAddress(IWebDriver driver) : base(driver)
        {
        }

        internal NewAddress SaveRecordwithRequiredFieldsOnly(TestUser User)

        {
            FirstName.SendKeys(User.firstname);
            LastName.SendKeys(User.lastname);
            Address1.SendKeys(User.address);
            City.SendKeys(User.city);
            ZipCode.SendKeys(User.zipcode);
            CreateAddress.Click();                    
            
            return new NewAddress(Driver);
        }


        internal NewAddress SaveRecordwithCountry(TestUser User)

        {
            switch (User.selectCountry)
            {
                case Country.UnitedStates:
                    break;
                case Country.Canada:
                    CanadaRadioButton.Click();
                    _logger.Info($"Selected Canada option=>{ CanadaRadioButton}");
                    break;
                default:
                    break;
            }
            FirstName.SendKeys(User.firstname);
            _logger.Info($"First Name selected=>{User.firstname}");
            LastName.SendKeys(User.lastname);
            Address1.SendKeys(User.address);
            _logger.Info($"Address selected=>{User.address}");
            City.SendKeys(User.city);
            ZipCode.SendKeys(User.zipcode);
            CreateAddress.Click();

            return new NewAddress(Driver);
        }


    }
}
