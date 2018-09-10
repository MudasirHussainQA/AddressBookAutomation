using OpenQA.Selenium;

namespace SampleApplication1
{
    internal class DashboardPage : BasePage
    {
        

        public DashboardPage(IWebDriver driver) : base(driver)
        {
            
        }       
                

        public bool IsVisible => Driver.Title.Contains("Address Book");

       







    }
}