namespace PressfordConsulting.News.IntegrationTests
{
    using System;

    public abstract class Page : PageObject
    {
        public static string Url { get; set; }

        protected Page(string url, string pageTitle)
        {
            Url = url;
            PageTitle = pageTitle;
        }

        /// <summary>
        /// Navigates to the page URL.
        /// </summary>
        public void Goto()
        {
            try
            {
                Browser.Goto(Url);
                WaitForLoad();
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format(
                        "{0} could not be loaded. Check page url is correct in App.config. Current url is {2}. {1}",
                        GetType().Name,
                        e.Message,
                        Browser.Url));
            }
        }

        /// <summary>
        /// Navigates to the page URL, but doesn't check the page titles match.
        /// Sometimes you call a page and get redirected somewhere else (if not logged in for example.
        /// </summary>
        public void GotoWithoutWait()
        {
            try
            {
                Browser.Goto(Url);
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format(
                        "{0} could not be loaded. Check page url is correct in App.config. Current url is {2}. {1}",
                        GetType().Name,
                        e.Message,
                        Browser.Url));
            }
        }

        /// <summary>
        /// Gets the page title.
        /// </summary>
        /// <returns>The current page title.</returns>
        public string GetPageTitle()
        {
            return Browser.Title;
        }
    }
}
