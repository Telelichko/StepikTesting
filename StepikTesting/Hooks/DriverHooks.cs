using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
namespace StepikTesting.Hooks
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using StepikTesting.Helpers;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class with driver actions before and after tests.
    /// </summary>
    [Binding]
    internal sealed class DriverHooks
    {
        /// <summary>
        /// Method with driver actions before tests.
        /// </summary>
        /// <param name="scenarioContext">Tests data.</param>
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver Webdriver;

            Webdriver = new ChromeDriver();

            scenarioContext.ScenarioContainer.RegisterInstanceAs(Webdriver);
        }

        /// <summary>
        /// Method with driver actions after tests.
        /// </summary>
        /// <param name="driver">WebDriver.</param>
        [AfterScenario(Order = 0)]
        public void MakeScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError is not null)
            {
                driver.SaveScreenshot(scenarioContext.ScenarioInfo.Title);
            }
        }

        /// <summary>
        /// Method with driver actions after tests.
        /// </summary>
        /// <param name="driver">WebDriver.</param>
        [AfterScenario(Order = 1)]
        public void AfterScenario(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
