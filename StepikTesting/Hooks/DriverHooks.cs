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
        private IWebDriver WebDriver;

        /// <summary>
        /// Method with driver actions before tests.
        /// </summary>
        /// <param name="scenarioContext">Tests data.</param>
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                "--headless",           // Run in headless mode
                "--no-sandbox",         // Bypass OS security model, necessary in Docker/GitLab CI
                "--disable-dev-shm-usage" // Overcome limited /dev/shm space in containers
            );

            WebDriver = new ChromeDriver(chromeOptions);

            scenarioContext.ScenarioContainer.RegisterInstanceAs<IWebDriver>(WebDriver);
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
