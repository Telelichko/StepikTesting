namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using Helpers;
    using StepikTesting.Components;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with steps in top menu.
    /// </summary>
    [Binding]
    internal class TopMenuSteps
    {
        private readonly TopMenuComponent _topMenu;

        public TopMenuSteps(TopMenuComponent topMenu)
        {
            _topMenu = topMenu;
        }

        #region Actions

        [Given(@"on top menu click user image button")]
        [AllureStep(@"on top menu click user image button")]
        public void TopMenuClickButtonUserImage()
        {
            WaitHelper.WaitUntilAction(() => _topMenu.ButtonUserImage != null && _topMenu.ButtonUserImage.Enabled);
            _topMenu.ButtonUserImage.Click();
        }

        [Given(@"on top menu click on button my study")]
        [AllureStep(@"on top menu click on button my study")]
        public void TopMenuClickButtonMyStudy()
        {
            WaitHelper.WaitUntilAction(() => _topMenu.ButtonMyStudy != null && _topMenu.ButtonMyStudy.Enabled);
            _topMenu.ButtonMyStudy.Click();
        }

        #endregion

        #region Asserts

        #endregion
    }
}