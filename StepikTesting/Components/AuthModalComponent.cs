namespace StepikTesting.Components
{
    using OpenQA.Selenium;
    using System.Linq;

    /// <summary>
    /// Class with elements in registration and login pages.
    /// </summary>
    internal class AuthModalComponent : BaseComponent
    {
        public AuthModalComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement? WindowAuth => _driver.FindElements(By.CssSelector("div.modal-dialog div.auth-widget"))
            .FirstOrDefault();

        public IWebElement? ButtonComeIn => _driver.FindElements(By.CssSelector("button.sign-form__btn"))
            .FirstOrDefault();

        public IWebElement? InputEmail => _driver.FindElements(By.CssSelector("input#id_login_email"))
            .FirstOrDefault();

        public IWebElement? InputPassword => _driver.FindElements(By.CssSelector("input#id_login_password"))
            .FirstOrDefault();
    }
}