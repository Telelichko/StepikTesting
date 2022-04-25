namespace StepikTesting.Pages
{
    using OpenQA.Selenium;

    /// <summary>
    /// Class with elements in user study page.
    /// </summary>
    internal class MyStudyPage : BasePage
    {
        public MyStudyPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MenuLeft => _driver.FindElements(By.CssSelector("nav[aria-labelledby='learn-nav-menu-label']"))
            .FirstOrDefault();

        public IWebElement ListItemCoursesInProgress => _driver.FindElements(By.CssSelector("a[href='/learn/courses']"))
            .FirstOrDefault();

        public IWebElement LinkCourseInList => _driver.FindElements(By.CssSelector("a.item-tile__title-link"))
            .FirstOrDefault();

        public IWebElement Title => _driver.FindElements(By.CssSelector("header h1"))
            .FirstOrDefault();
    }
}