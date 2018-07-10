namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class Homepage : Page
    {
        /// <summary>
        /// The most popular articles panel
        /// </summary>
        [FindsBy(How = How.Id, Using = "popularPanel")]
        IWebElement PopularPanel { get; set; }

        /// <summary>
        /// The most popular articles chart
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#popularPanel canvas")]
        IWebElement PopularChart { get; set; }

        /// <summary>
        /// The news articles
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#newsArticles .card-panel")]
        IList<IWebElement> NewsArticles { get; set; }

        /// <summary>
        /// The news article titles
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "#newsArticles .card-content span.card-title")]
        IList<IWebElement> NewsArticleTitles { get; set; }

        /// <summary>
        /// The add new article button
        /// </summary>
        [FindsBy(How = How.Id, Using = "btnAddArticle")]
        IWebElement AddNewArticleButton { get; set; }

        /// <summary>
        /// The Help navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "logoutForm")]
        IWebElement LogoutForm { get; set; }

        /// <summary>
        /// The Register navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "registerLink")]
        IWebElement RegisterButton { get; set; }

        /// <summary>
        /// The Login navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "loginLink")]
        IWebElement LoginButton { get; set; }

        /// <summary>
        /// The News navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "newsLink")]
        IWebElement NewsButton { get; set; }

        /// <summary>
        /// The Help navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "helpLink")]
        IWebElement HelpButton { get; set; }

        /// <summary>
        /// The Contact navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "contactLink")]
        IWebElement ContactButton { get; set; }

        /// <summary>
        /// The Home navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "homeLink")]
        IWebElement HomeButton { get; set; }

        /// <summary>
        /// The hellow text in the page header
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = "nav span.right")]
        IWebElement HelloText { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Homepage"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="pageTitle">The page title.</param>
        public Homepage(string url, string pageTitle)
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
        /// Logouts the button visible.
        /// </summary>
        /// <returns><c>true</c> if the logout button is visible, <c>false</c> otherwise.</returns>
        public bool IsLogoutButtonVisible()
        {
            WaitForLoad();

            try
            {
                return LogoutForm.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is the register button visible.
        /// </summary>
        /// <returns><c>true</c> if the register button is visible, <c>false</c> otherwise.</returns>
        public bool IsRegisterButtonVisible()
        {
            WaitForLoad();

            try
            {
                return RegisterButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is the login button visible.
        /// </summary>
        /// <returns><c>true</c> if the login button is visible, <c>false</c> otherwise.</returns>
        public bool IsLoginButtonVisible()
        {
            WaitForLoad();

            try
            {
                return LoginButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Is the hello text visible.
        /// </summary>
        /// <returns><c>true</c> if the  hello text is visible, <c>false</c> otherwise.</returns>
        public bool IsHelloTextVisible()
        {
            WaitForLoad();

            try
            {
                return HelloText.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
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

        public ReadArticlePage ReadFirstNewsArticleWithImage()
        {
            WaitForLoad();

            var allArticles = NewsArticles;
            foreach (var article in allArticles)
            {
                try
                {
                    var url = article
                        .FindElement(By.CssSelector(".card-image a"))
                        .GetAttribute("href");
                    var image = article.FindElement(By.CssSelector(".card-image"));
                    image.Click();
                    return new ReadArticlePage(url, Helper.ReadArticlePageTitle);
                }
                catch (NoSuchElementException)
                {
                }
            }

            return new ReadArticlePage(Helper.ReadArticlePage.AbsoluteUri, Helper.ReadArticlePageTitle);
        } 

        /// <summary>
        /// Latest news articles are displayed.
        /// </summary>
        /// <returns><c>true</c> if the latest news articles are visible, <c>false</c> otherwise.</returns>
        public bool LatestNewsArticlesExist()
        {
            WaitForLoad();

            return NewsArticles.Any();
        }

        /// <summary>
        /// Most popular panel exists with chart.
        /// </summary>
        /// <returns><c>true</c> if the most popular panel exists with a chart & is visible, <c>false</c> otherwise.</returns>
        public bool MostPopularPanelExistsWithChart()
        {
            WaitForLoad();

            try
            {
                var panelDisplayed = PopularPanel.Displayed;
                if (!panelDisplayed)
                {
                    return false;
                }

                var chartDisplayed = PopularChart.Displayed;
                return chartDisplayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks the register navigation button.
        /// </summary>
        /// <returns>The expected <see cref="LoginPage"/> that should result from this action.</returns>
        public LoginPage Logout()
        {
            WaitForLoad();

            LogoutForm.Submit();

            return new LoginPage(Helper.LoginPage.AbsoluteUri, Helper.LoginPageTitle);
        }

        /// <summary>
        /// Clicks the home navigation button.
        /// </summary>
        /// <returns>The expected <see cref="Homepage"/> that should result from this action.</returns>
        public Homepage ClickHome()
        {
            WaitForLoad();

            HomeButton.Click();

            return new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
        }

        /// <summary>
        /// Clicks the news navigation button.
        /// </summary>
        /// <returns>The expected <see cref="NewsPage"/> that should result from this action.</returns>
        public NewsPage ClickNews()
        {
            WaitForLoad();

            NewsButton.Click();

            return new NewsPage(Helper.NewsPage.AbsoluteUri, Helper.NewsPageTitle);
        }

        /// <summary>
        /// Clicks the contactnavigation  button.
        /// </summary>
        public void ClickContact()
        {
            WaitForLoad();

            ContactButton.Click();
        }

        /// <summary>
        /// Clicks the help navigation button.
        /// </summary>
        public void ClickHelp()
        {
            WaitForLoad();

            HelpButton.Click();
        }
    }
}
