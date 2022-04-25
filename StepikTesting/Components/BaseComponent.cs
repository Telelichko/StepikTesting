namespace StepikTesting.Components
{
    using OpenQA.Selenium;

    /// <summary>
    /// Page parent class for components.
    /// </summary>
    public abstract class BaseComponent
    {
        protected readonly IWebDriver _driver;

        public BaseComponent(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}