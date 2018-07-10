namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class NewArticlePage : Page
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
        /// The add article button
        /// </summary>
        [FindsBy(How = How.Name, Using = "action")]
        IWebElement AddButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".field-validation-error")]
        IList<IWebElement> Errors { get; set; }

        public NewArticlePage(string url, string pageTitle) 
            : base(url, pageTitle)
        {
        }

        /// <summary>
        /// Add article the button visible.
        /// </summary>
        /// <returns><c>true</c> if the add button is visible, <c>false</c> otherwise.</returns>
        public bool IsAddButtonVisible()
        {
            WaitForLoad();

            try
            {
                return AddButton.Displayed;
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

            return Title.Text;
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
        /// Gets the current image
        /// </summary>
        /// <returns>The current image text from the editor.</returns>
        public string GetImage()
        {
            WaitForLoad();

            return Image.Text;
        }

        /// <summary>
        /// Add a new article
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="image">The image.</param>
        /// <returns>
        /// The expected <see cref="Homepage" /> that should result from this action.
        /// </returns>
        public Homepage AddNewArticle(string title, string content, string image)
        {
            WaitForLoad();

            Title.Clear();
            Title.SendKeys(title);

            Content.Clear();
            Content.SendKeys(content);

            Image.Clear();
            Image.SendKeys(image);

            AddButton.Click();

            return new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
        }

        /// <summary>
        /// Click the add button
        /// </summary>
        /// <returns>The expected <see cref="NewArticlePage"/> that should result from this action.</returns>
        public NewArticlePage Submit()
        {
            WaitForLoad();

            AddButton.Click();

            return new NewArticlePage(Helper.NewArticlePage.AbsoluteUri, Helper.NewArticlePageTitle);
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
