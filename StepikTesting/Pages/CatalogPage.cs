namespace StepikTesting.Pages
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    /// <summary>
    /// Class with elements in catalog page.
    /// </summary>
    internal class CatalogPage : BasePage
    {
        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonEnrollCourse => _driver.FindElements(By.CssSelector("aside.course-promo__main-aside button.course-promo-enrollment__join-btn"))
            .FirstOrDefault();

        public IWebElement ButtonOk => _driver.FindElements(By.CssSelector("button.search-form__submit"))
            .FirstOrDefault();

        public IWebElement InputSearch => _driver.FindElements(By.CssSelector("input.search-form__input"))
            .FirstOrDefault();

        public IWebElement TextNoCourses => _driver.FindElements(By.CssSelector("p.catalog__search-results-message"))
            .FirstOrDefault();

        public List<IWebElement> ListItems => _driver.FindElements(By.CssSelector("div[data-list-type='search-results'] li"))
            .ToList();

        public IReadOnlyCollection<IWebElement> Titles => _driver.FindElements(By.XPath("//h1"));
    }
}