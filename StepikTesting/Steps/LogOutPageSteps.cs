namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using StepikTesting.Components;
    using StepikTesting.Helpers;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with steps in logout page.
    /// </summary>
    [Binding]
    internal class LogOutPageSteps
    {
        private readonly LogOutModalComponent _logOutPage;

        public LogOutPageSteps(LogOutModalComponent logOutPage)
        {
            _logOutPage = logOutPage;
        }

        #region Actions

        [Given(@"on logout page click button ok")]
        [AllureStep(@"on logout page click button ok")]
        public void LogOutPageClickButtonOk()
        {
            WaitHelper.WaitUntilAction(() => _logOutPage.ButtonOk != null && _logOutPage.ButtonOk.Enabled);
            _logOutPage.ButtonOk.Click();
        }

        #endregion

        #region Asserts

        #endregion
    }
}