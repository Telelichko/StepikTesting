namespace StepikTesting.Helpers
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    /// <summary>
    /// Class for screenshots.
    /// </summary>
    public static class ScreenshotHelper
    {
        public static void SaveScreenshot(this IWebDriver webDriver, string name)
        {
            var screenShotFilePath = GetPathToScreenshotFile(name);

            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            screenshot.SaveAsFile(screenShotFilePath);
            TestContext.AddTestAttachment(screenShotFilePath);
        }

        private static string GetPathToScreenshotFile(string name)
        {
            var directoryPath = Path.Combine(Path.GetTempPath(), "Screenshots");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return Path.Combine(
                directoryPath,
                $"screenshot-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}_{name}.png");
        }
    }
}