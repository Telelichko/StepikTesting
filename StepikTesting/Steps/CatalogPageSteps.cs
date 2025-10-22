namespace StepikTesting.Steps
{
    using Allure.NUnit.Attributes;

    using FluentAssertions;
    using StepikTesting.Helpers;
    using StepikTesting.Pages;
    using System;
    using System.Linq;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with steps in catalog page.
    /// </summary>
    [Binding]
    internal class CatalogPageSteps
    {
        private readonly CatalogPage _сatalogPage;

        public CatalogPageSteps(CatalogPage сatalogPage)
        {
            _сatalogPage = сatalogPage;
        }

        #region Actions

        [Given(@"on catalog page click button ok")]
        [AllureStep(@"on catalog page click button ok")]
        public void CatalogPageClickButtonOk()
        {
            WaitHelper.WaitUntilAction(() => _сatalogPage.ButtonOk != null && _сatalogPage.ButtonOk.Enabled);
            _сatalogPage.ButtonOk.Click();
        }

        [Given(@"on catalog page fill search input -> ""(.*)""")]
        [AllureStep(@"on catalog page fill search input -> ""(.*)""")]
        public void CatalogPageFillSearchInput(string inputValue)
        {
            WaitHelper.WaitUntilAction(() => (_сatalogPage.InputSearch != null && _сatalogPage.InputSearch.Enabled));
            _сatalogPage.InputSearch.SendKeys(inputValue);
        }

        [Given(@"on catalog page add course from list by number ""(.*)""")]
        [AllureStep(@"on catalog page add course from list by number ""(.*)""")]
        public void CatalogPageAddNewCourseFromList(int courseNumber)
        {
            WaitHelper.WaitUntilAction(() => _сatalogPage.ListItems.Count != 0 && _сatalogPage.ListItems.First().Enabled);
            var courses = _сatalogPage.ListItems;

            try
            {
                courses[courseNumber - 1].Click();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException($"There isn't course N {courseNumber} in list.");
            }
        }

        #endregion

        #region Asserts

        [Then(@"on catalog page there is title ""(.*)""")]
        [AllureStep(@"on catalog page there is title ""(.*)""")]
        public void AssertStepTitleEquelToValue(string titleValue)
        {
            WaitHelper.WaitUntilAction(() => _сatalogPage.Titles.Count != 0 && _сatalogPage.Titles.First().Enabled);
            var titles = _сatalogPage.Titles
                .Where(x => x.Displayed && x.Text.Contains(titleValue))
                .FirstOrDefault();

            titles.Should().NotBeNull();
        }

        [Then(@"on catalog page there are some courses")]
        [AllureStep(@"on catalog page there are some courses")]
        public void AssertStepCoursesOnPage()
        {
            WaitHelper.WaitUntilAction(() => (_сatalogPage.ListItems.Count != 0 && _сatalogPage.ListItems.First().Enabled)
                                             && _сatalogPage.TextNoCourses == null);
            var courses = _сatalogPage.ListItems;

            courses.Should().NotBeNull();
        }

        [Then(@"on catalog page there aren't some courses")]
        [AllureStep(@"on catalog page there aren't some courses")]
        public void AssertStepNoCoursesOnPage()
        {
            WaitHelper.WaitUntilAction(() => _сatalogPage.ListItems.Count == 0);
            var courses = _сatalogPage.ListItems;

            courses.Should().BeEmpty();
        }

        [Then(@"on catalog page there is message -> ""(.*)""")]
        public void AssertStepNoCoursesOnPage(string expectedMessage)
        {
            WaitHelper.WaitUntilAction(() => _сatalogPage.TextNoCourses != null
                                             && _сatalogPage.TextNoCourses.Displayed);
            var textNoCourses = _сatalogPage.TextNoCourses;

            textNoCourses.Text.Should().Contain(expectedMessage);
        }

        #endregion
    }
}