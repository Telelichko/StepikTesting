namespace StepikTesting.Pages
{
    using Components;
    using OpenQA.Selenium;

    /// <summary>
    /// Page parent class for pages.
    /// </summary>
    internal class BasePage
    {
        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        internal AuthModalComponent AuthModalComponent => new AuthModalComponent(_driver);

        internal LogOutModalComponent LogOutModalComponent => new LogOutModalComponent(_driver);

        internal TopMenuComponent TopMenuComponent => new TopMenuComponent(_driver);

        internal UserMenuComponent UserMenuComponent => new UserMenuComponent(_driver);

        public virtual void WaitUntillPageLoadFinish()
        {
            string pageState = null;
            while (pageState != "complete")
            {
                string script = "return document.readyState;";

                pageState = ((IJavaScriptExecutor)_driver).ExecuteScript(script).ToString();
            }
        }
    }
}
