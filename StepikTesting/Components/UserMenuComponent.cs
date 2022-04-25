namespace StepikTesting.Components
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class with elements in catalog page, menu under user image
    /// </summary>
    internal class UserMenuComponent : BaseComponent
    {
        public UserMenuComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonLogOut => _driver.FindElements(By.CssSelector("li[data-qa='menu-item-logout']"))
            .FirstOrDefault();

        public IWebElement ButtonProfile => _driver.FindElements(By.CssSelector("button.navbar__profile-toggler"))
            .FirstOrDefault();
    }
}