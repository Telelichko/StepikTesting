using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(8)]
namespace StepikTesting.Hooks
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Segment.Model;
    using OpenQA.Selenium.Remote;

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
            IWebDriver webDriver;
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--headless=new"); // Run headless in CI
            chromeOptions.AddArgument("--window-size=1920,1080");

            if (Environment.GetEnvironmentVariable("GITLAB_CI") != null)
            {
                webDriver = new RemoteWebDriver(new Uri("http://selenium-standalone:4444/wd/hub"), chromeOptions.ToCapabilities());
            }
            else
            {
                webDriver = new ChromeDriver(chromeOptions);
            }

            scenarioContext.ScenarioContainer.RegisterInstanceAs(webDriver);
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
