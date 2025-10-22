namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using Helpers;
    using StepikTesting.Components;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with steps in user menu.
    /// </summary>
    [Binding]
    internal class UserMenuSteps
    {
        private readonly UserMenuComponent _userMenu;

        public UserMenuSteps(UserMenuComponent userMenu)
        {
            _userMenu = userMenu;
        }

        #region Actions

        [Given(@"on user menu click button log out")]
        [AllureStep(@"on user menu click button log out")]
        public void UserMenuClickButtonLogOut()
        {
            WaitHelper.WaitUntilAction(() => _userMenu.ButtonLogOut != null && _userMenu.ButtonLogOut.Enabled);
            _userMenu.ButtonLogOut.Click();
        }

        [Given(@"on user menu click button profile")]
        [AllureStep(@"on user menu click button profile")]
        public void UserMenuClickButtonProfile()
        {
            WaitHelper.WaitUntilAction(() => _userMenu.ButtonProfile != null && _userMenu.ButtonProfile.Enabled);
            _userMenu.ButtonProfile.Click();
        }

        #endregion

        #region Asserts

        #endregion
    }
}