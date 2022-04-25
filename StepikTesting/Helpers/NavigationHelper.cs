namespace StepikTesting.Helpers
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class with actions without page.
    /// </summary>
    internal class NavigationHelper
    {
        private readonly IWebDriver Driver;

        public NavigationHelper(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Navigation to url.
        /// </summary>
        /// <param name="url">Site url.</param>
        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}