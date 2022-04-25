namespace StepikTesting.Helpers
{
    using System.Diagnostics;

    /// <summary>
    /// Class with different waiting.
    /// </summary>
    internal static class WaitHelper
    {
        /// <summary>
        /// Method with waiting certain time.
        /// </summary>
        /// <param name="action">Delegate</param>
        /// <param name="maxSeconds">Waiting time</param>
        /// <exception cref="TimeoutException"></exception>
        public static void WaitUntilAction(Func<bool> action, int maxSeconds = 10, string timeoutExeptionMessage = null)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                while (stopwatch.ElapsedMilliseconds < maxSeconds * 1000)
                {
                    if (action())
                    {
                        return;
                    }

                    Thread.Sleep(100);
                }

                throw new TimeoutException(timeoutExeptionMessage ?? $"Action isn't true.");
            }
            finally
            {
                stopwatch.Stop();
            }
        }
    }
}