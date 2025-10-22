namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using Components;
    using StepikTesting.Helpers;
    using StepikTesting.Pages;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with common steps 
    /// </summary>
    [Binding]
    internal class CommonSteps : BaseSteps<BasePage>
    {
        public CommonSteps(BasePage page) : base(page)
        {
        }

        #region Actions

        [Given(@"login as ""(.*)"" -> ""(.*)""")]
        [AllureStep(@"login as ""(.*)"" -> ""(.*)""")]
        public void Login(string login, string password)
        {
            AuthModalComponent authPage = _currentPage.AuthModalComponent;

            TopMenuComponent topMenu = _currentPage.TopMenuComponent;

            WaitHelper.WaitUntilAction(() => topMenu.ButtonComeIn != null && topMenu.ButtonComeIn.Enabled);

            WaitHelper.WaitUntilAction(() =>
            {
                try
                {
                    if (authPage.WindowAuth == null || !authPage.WindowAuth.Displayed)
                    {
                        topMenu.ButtonComeIn.Click();
                    }

                    return authPage.WindowAuth != null && authPage.WindowAuth.Displayed;
                }
                catch
                {
                    return false;
                }
            });

            authPage.InputEmail.SendKeys(login);

            authPage.InputPassword.SendKeys(password);

            authPage.ButtonComeIn.Click();
        }

        [Given(@"logout")]
        [AllureStep(@"logout")]
        public void Logout()
        {
            var logOutPage = _currentPage.LogOutModalComponent;

            var userMenu = _currentPage.UserMenuComponent;

            WaitHelper.WaitUntilAction(() => userMenu.ButtonLogOut != null && userMenu.ButtonLogOut.Enabled);
            userMenu.ButtonLogOut.Click();

            WaitHelper.WaitUntilAction(() => logOutPage.ButtonOk != null && logOutPage.ButtonOk.Enabled);
            logOutPage.ButtonOk.Click();
        }

        #endregion

        #region Asserts

        #endregion
    }
}