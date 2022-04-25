namespace StepikTesting.Steps
{
    using Pages;

    /// <summary>
    /// Page parent class for steps.
    /// </summary>
    /// <typeparam name="TPage">Delegator with pages</typeparam>
    internal class BaseSteps<TPage>
        where TPage : BasePage
    {
        protected TPage _currentPage;

        public BaseSteps(
            TPage page)
        {
            _currentPage = page;
        }
    }
}