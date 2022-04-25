namespace StepikTesting.Components
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class with elements in catalog page, top menu.
    /// </summary>
    internal class TopMenuComponent : BaseComponent
    {
        public TopMenuComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonComeIn => _driver.FindElements(By.CssSelector("a.navbar__auth_login"))
            .FirstOrDefault();

        public IWebElement ButtonMyStudy => _driver.FindElements(By.CssSelector("ul.navbar__links li[data-navbar-item='learn'] a.st-link"))
            .FirstOrDefault();

        public IWebElement ButtonUserImage => _driver.FindElements(By.CssSelector("button.navbar__profile-toggler"))
            .FirstOrDefault();
    }
}