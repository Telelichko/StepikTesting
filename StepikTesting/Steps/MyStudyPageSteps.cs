namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using FluentAssertions;
    using StepikTesting.Helpers;
    using StepikTesting.Pages;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with steps in user study page.
    /// </summary>
    [Binding]
    internal class MyStudyPageSteps
    {
        private readonly MyStudyPage _myStudyPage;

        public MyStudyPageSteps(MyStudyPage myStudyPage)
        {
            _myStudyPage = myStudyPage;
        }

        #region Actions

        [Given(@"on my study page click on button course in progress")]
        [When(@"on my study page click on button course in progress")]
        [AllureStep(@"on my study page click on button course in progress")]
        public void MyStudyPageClickButtonCoursesInProgress()
        {
            WaitHelper.WaitUntilAction(() => _myStudyPage.ListItemCoursesInProgress != null && _myStudyPage.ListItemCoursesInProgress.Enabled);
            _myStudyPage.ListItemCoursesInProgress.Click();
        }

        #endregion

        #region Asserts

        [Then(@"on my study page there is left menu")]
        [AllureStep(@"on my study page there is left menu")]
        public void AssertStepMenuLeftExist()
        {
            WaitHelper.WaitUntilAction(() => _myStudyPage.MenuLeft != null && _myStudyPage.MenuLeft.Enabled);
            var menuLeft = _myStudyPage.MenuLeft;

            menuLeft.Should().NotBeNull();
        }

        [Then(@"on my study page there is title ""(.*)""")]
        [AllureStep(@"on my study page there is title ""(.*)""")]
        public void AssertStepCertainTitleExist(string expectedTitleText)
        {
            WaitHelper.WaitUntilAction(() => _myStudyPage.Title != null && _myStudyPage.Title.Enabled);
            var actualTitleElement = _myStudyPage.Title;

            actualTitleElement.Text.Should().Contain(expectedTitleText);
        }

        [Then(@"on my study page there is a course in progress ""(.*)""")]
        [AllureStep(@"on my study page there is a course in progress ""(.*)""")]
        public void AssertStepCourseInList(string expectedCourseName)
        {
            WaitHelper.WaitUntilAction(() => _myStudyPage.LinkCourseInList != null && _myStudyPage.LinkCourseInList.Enabled);
            var actualCourseName = _myStudyPage.LinkCourseInList;

            actualCourseName.Text.Should().Contain(expectedCourseName);
        }

        #endregion
    }
}