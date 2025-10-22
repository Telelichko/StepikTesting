namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using Pages;
    using StepikTesting.Helpers;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with navigation steps.
    /// </summary>
    [Binding]
    internal class NavigateSteps : BaseSteps<BasePage>
    {
        private readonly NavigationHelper _navigationHelper;

        public NavigateSteps(BasePage page, NavigationHelper navigationHelper) : base(page)
        {
            _navigationHelper = navigationHelper;
        }

        #region Actions

        [Given(@"go to url ""(.*)""")]
        [AllureStep(@"go to url ""(.*)""")]
        public void NavigationGoToUrl(string url)
        {
            _navigationHelper.GoToURL(url);
        }

        [Given(@"wait until page load")]
        [AllureStep(@"wait until page load")]
        public void WaitUntilPageLoad()
        {
            _currentPage.WaitUntillPageLoadFinish();
        }

        [Given(@"wait for ""(.*)"" seconds")]
        [AllureStep(@"wait for ""(.*)"" seconds")]
        public void NavigationWaitForWail(double time)
        {
            Thread.Sleep(Convert.ToInt32(time * 1000));
        }

        #endregion

        #region Asserts

        #endregion
    }
}