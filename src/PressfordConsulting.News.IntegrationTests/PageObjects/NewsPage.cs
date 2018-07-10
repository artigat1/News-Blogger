namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// Selenium page object representation of the News page (homepage)
    /// </summary>
    public class NewsPage : Page
    {
        /// <summary>
        /// The news articles
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".card-panel")]
        IList<IWebElement> NewsArticles { get; set; }

        /// <summary>
        /// The news article titles
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".card-content span.card-title")]
        IList<IWebElement> NewsArticleTitles { get; set; }

        /// <summary>
        /// The add new article button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnAddArticle")]
        IWebElement AddNewArticleButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsPage"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="pageTitle">The page title.</param>
        public NewsPage(string url, string pageTitle)
            : base(url, pageTitle)
        {
        }

        /// <summary>
        /// Gets the count of all news aticles on the news page.
        /// </summary>
        /// <returns>The <see cref="int"/> count.</returns>
        public int GetNewsArticlesCount()
        {
            WaitForLoad();

            return NewsArticles.Count;
        }

        /// <summary>
        /// Is new story button visible.
        /// </summary>
        /// <returns><c>true</c> if button is visible, <c>false</c> otherwise.</returns>
        public bool IsNewArticleButtonVisible()
        {
            WaitForLoad();

            try
            {
                return AddNewArticleButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Click the new article button
        /// </summary>
        public void ClickNewArticleButton()
        {
            WaitForLoad();

            AddNewArticleButton.Click();
        }

        /// <summary>
        /// News article exists with <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns><c>true</c> if the an article with the title is visible, <c>false</c> otherwise.</returns>
        public bool NewsArticleExistsWithTitle(string title)
        {
            WaitForLoad();

            var allTitles = NewsArticleTitles;
            var exists = from x in allTitles
                         where String.Equals(x.Text, title, StringComparison.CurrentCultureIgnoreCase)
                         select x;

            return exists.Any();
        }

        /// <summary>
        /// Reads the first article.
        /// </summary>
        /// <returns>The expected <see cref="ReadArticlePage"/> that should result from this action.</returns>
        public ReadArticlePage ReadFirstArticle()
        {
            WaitForLoad();

            var article = NewsArticles.FirstOrDefault();
            if (article == null)
            {
                return new ReadArticlePage(Helper.ReadArticlePage.AbsoluteUri, Helper.ReadArticlePageTitle);
            }

            var readNowLink = article.FindElement(By.CssSelector(".card-action a"));
            var url = readNowLink.GetAttribute("href");
            var title = article.FindElement(By.CssSelector(".card-title")).Text;
            var pageTitle = string.Format("{0} | {1}", title, Helper.ReadArticlePageTitle);
            readNowLink.Click();

            return new ReadArticlePage(url, pageTitle);
        }
    }
}
