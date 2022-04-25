namespace StepikTesting.Components
{
    using OpenQA.Selenium;
    using System.Linq;

    /// <summary>
    /// Class with elements in logout page
    /// </summary>
    internal class LogOutModalComponent : BaseComponent
    {
        public LogOutModalComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonOk => _driver.FindElements(By.XPath("//footer/child::button[1]"))
            .FirstOrDefault();
    }
}