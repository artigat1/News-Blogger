namespace PressfordConsulting.News.IntegrationTests
{
    using System;
    using OpenQA.Selenium;

    public abstract class PageObject
    {
        internal static string PageTitle { get; set; }

        /// <summary>
        /// Checks if the browser is on the calling page.
        /// </summary>
        /// <returns>Returs <c>true</c> if the browser is on the page, otherwise <c>false</c>.</returns>
        public bool IsAt()
        {
            return Browser.Title.Contains(PageTitle);
        }

        /// <summary>
        /// Makes the browser wait until an element that matches the given find by method is found on the page.
        /// </summary>
        /// <param name="elementDesc">The method to use to find the element</param>
        internal static void WaitFor(By elementDesc)
        {
            var wait = Browser.Wait();

            wait.Until(e => e.FindElement(elementDesc));
        }

        /// <summary>
        /// Makes the browser wait until the page is loaded.
        /// </summary>
        internal void WaitForLoad()
        {
            var wait = Browser.Wait();

            wait.Until(p => p.Title.Contains(PageTitle));
        }

        /// <summary>
        /// Waits until the page source contains the specified keyword.
        /// </summary>
        /// <param name="keyWord">The key word to be checked for.</param>
        internal void WaitFor(string keyWord)
        {
            var wait = Browser.Wait();
            
            wait.Until(p => p.PageSource.Contains(keyWord));
        }

        /// <summary>
        /// Checks if the current page contains the specified keyword.
        /// </summary>
        /// <param name="keyWord">The keyword to be checked for.</param>
        /// <returns>Returs <c>true</c> if the word if found on the page, otherwise <c>false</c>.</returns>
        internal bool CheckPage(string keyWord)
        {
            return Browser.PageSource.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
