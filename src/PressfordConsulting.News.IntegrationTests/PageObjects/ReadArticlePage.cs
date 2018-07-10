namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class ReadArticlePage : Page
    {
        /// <summary>
        /// The article title
        /// </summary>
        [FindsBy(How = How.TagName, Using = "h1")]
        IWebElement Title { get; set; }

        /// <summary>
        /// The article content
        /// </summary>
        [FindsBy(How = How.Id, Using = "content")]
        IWebElement Content { get; set; }

        /// <summary>
        /// The article author
        /// </summary>
        [FindsBy(How = How.Id, Using = "author")]
        IWebElement Author { get; set; }

        /// <summary>
        /// The date the article was published
        /// </summary>
        [FindsBy(How = How.Id, Using = "publishDate")]
        IWebElement PublishDate { get; set; }

        /// <summary>
        /// The main action button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnMain")]
        IWebElement MainActionButton { get; set; }

        /// <summary>
        /// The edit article button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnEdit")]
        IWebElement EditArticleButton { get; set; }

        /// <summary>
        /// The delete article button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnDelete")]
        IWebElement DeleteArticleButton { get; set; }

        /// <summary>
        /// The delete confirmation popup
        /// </summary>
        [FindsBy(How = How.Id, Using = "confirmDelete")]
        IWebElement DeleteConfirmation { get; set; }

        /// <summary>
        /// The delete confirmation popup ok button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnDeleteOk")]
        IWebElement DeleteConfirmationOkBtn { get; set; }

        /// <summary>
        /// The delete confirmation popup cancel button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnDeleteCancel")]
        IWebElement DeleteConfirmationCancelBtn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadArticlePage"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="pageTitle">The page title.</param>
        public ReadArticlePage(string url, string pageTitle) 
            : base(url, pageTitle)
        {
        }

        /// <summary>
        /// Is article has a title visible.
        /// </summary>
        /// <returns><c>true</c> if article title is visible, <c>false</c> otherwise.</returns>
        public bool IsArticleTitleVisible()
        {
            WaitForLoad();

            try
            {
                return Title.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is article has the author name visible.
        /// </summary>
        /// <returns><c>true</c> if article has the author name is visible, <c>false</c> otherwise.</returns>
        public bool IsArticleAuthorVisible()
        {
            WaitForLoad();

            try
            {
                return Author.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is article's published date is visible.
        /// </summary>
        /// <returns><c>true</c> if article's published date is visible, <c>false</c> otherwise.</returns>
        public bool IsArticlePublishedDateVisible()
        {
            WaitForLoad();

            try
            {
                return PublishDate.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is article has a content visible.
        /// </summary>
        /// <returns><c>true</c> if article content is visible, <c>false</c> otherwise.</returns>
        public bool IsArticleContentVisible()
        {
            WaitForLoad();

            try
            {
                return Content.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is the main action button visible.
        /// </summary>
        /// <returns><c>true</c> if action buttone is visible, <c>false</c> otherwise.</returns>
        public bool IsMainActionButtonVisible()
        {
            WaitForLoad();

            try
            {
                return MainActionButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Click the main action button.
        /// </summary>
        /// <returns>The expected <see cref="NewArticlePage"/> that should result from this action.</returns>
        public NewArticlePage ClickMainActionButton()
        {
            WaitForLoad();

            try
            {
                MainActionButton.Click();
            }
            catch (NoSuchElementException)
            {
            }

            return new NewArticlePage(Helper.NewArticlePage.AbsoluteUri, Helper.NewArticlePageTitle);
        }
    }
}
