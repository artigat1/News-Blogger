namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class EditArticlePage : Page
    {
        /// <summary>
        /// The article title
        /// </summary>
        [FindsBy(How = How.Id, Using = "Title")]
        IWebElement Title { get; set; }

        /// <summary>
        /// The article content
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".froala-view")]
        IWebElement Content { get; set; }

        /// <summary>
        /// The article image
        /// </summary>
        [FindsBy(How = How.Id, Using = "Image")]
        IWebElement Image { get; set; }

        /// <summary>
        /// The article update button
        /// </summary>
        [FindsBy(How = How.Name, Using = "action")]
        IWebElement UpdateButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".field-validation-error")]
        IList<IWebElement> Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditArticlePage"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="pageTitle">The page title.</param>
        public EditArticlePage(string url, string pageTitle) 
            : base(url, pageTitle)
        {
        }

        /// <summary>
        /// Update article the button visible.
        /// </summary>
        /// <returns><c>true</c> if the update button is visible, <c>false</c> otherwise.</returns>
        public bool IsUpdateButtonVisible()
        {
            WaitForLoad();

            try
            {
                return UpdateButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the current title value
        /// </summary>
        /// <returns>The current title text from the input box.</returns>
        public string GetTitle()
        {
            WaitForLoad();

            return Title.GetAttribute("value");
        }

        /// <summary>
        /// Gets the current content
        /// </summary>
        /// <returns>The current content text from the editor.</returns>
        public string GetContent()
        {
            WaitForLoad();

            return Content.Text;
        }

        /// <summary>
        /// Gets the current article image
        /// </summary>
        /// <returns>The current content text from the editor.</returns>
        public string GetImage()
        {
            WaitForLoad();

            return Content.Text;
        }

        /// <summary>
        /// Update the title and content of the article
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="image">The image.</param>
        /// <returns>The expected <see cref="Homepage"/> that should result from this action.</returns>
        public Homepage UpdateArticle(string title, string content, string image)
        {
            WaitForLoad();

            Title.Clear();
            Title.SendKeys(title);

            Content.Clear();
            Content.SendKeys(content);

            Image.Clear();
            Image.SendKeys(image);

            UpdateButton.Click();

            return new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
        }

        /// <summary>
        /// Removes the title, image and content and then clicks the update button
        /// </summary>
        /// <returns>The expected <see cref="EditArticlePage"/> that should result from this action.</returns>
        public EditArticlePage RemoveContentAndSubmit()
        {
            WaitForLoad();

            Title.Clear();

            Content.Clear();

            Image.Clear();

            UpdateButton.Click();

            return new EditArticlePage(Helper.EditArticlePage.AbsoluteUri, Helper.EditArticlePageTitle);
        }

        /// <summary>
        /// Determines whether this page has errors displayed.
        /// </summary>
        /// <returns><c>true</c> if the page has errors displayed, <c>false</c> otherwise.</returns>
        public bool HasErrors()
        {
            WaitForLoad();

            return Errors.Any();
        }
    }
}
