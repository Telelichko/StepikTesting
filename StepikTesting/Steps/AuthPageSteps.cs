namespace StepikTesting.Steps
{
    using Components;
    using FluentAssertions;
    using StepikTesting.Helpers;
    using TechTalk.SpecFlow;
    using Allure.NUnit;
    using Allure.NUnit.Attributes;
    using NUnit.Framework;

    /// <summary>
    /// Class with steps in registration and login pages.
    /// </summary>
    [Binding]
    [AllureNUnit]
    internal class AuthPageSteps
    {
        private readonly AuthModalComponent _authPage;

        private readonly NavigationHelper _navigationHelper;

        public AuthPageSteps(AuthModalComponent authPage, NavigationHelper navigationHelper)
        {
            _authPage = authPage;
            _navigationHelper = navigationHelper;
        }

        #region Actions

        #endregion

        #region Asserts

        [Then(@"on auth page not visible")]
        [AllureStep(@"on auth page not visible")]
        public void AssertWindowNotVisible()
        {
            WaitHelper.WaitUntilAction(() => _authPage.WindowAuth == null);
            var windowAuth = _authPage.WindowAuth;

            windowAuth.Should().BeNull();
        }

        [Then(@"on auth page visible")]
        [AllureStep(@"on auth page visible")]
        public void AssertWindowVisible()
        {
            WaitHelper.WaitUntilAction(() => _authPage.WindowAuth != null && _authPage.WindowAuth.Enabled);
            var windowAuth = _authPage.WindowAuth;

            windowAuth.Should().NotBeNull();
        }

        [Then(@"on auth page there is alert below button ok ""(.*)""")]
        [AllureStep(@"on auth page there is alert below button ok ""(.*)""")]
        public void AssertIsAlertWithCertainTextExist(string expectedAlertMessage)
        {
            var actualAlertMessage = _authPage.InputEmail.GetAttribute("validationMessage");

            actualAlertMessage.Should().Contain(expectedAlertMessage);
        }

        #endregion
    }
}