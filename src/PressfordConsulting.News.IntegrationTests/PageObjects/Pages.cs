namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using OpenQA.Selenium.Support.PageObjects;

    /// <summary>
    /// This class allows access to system pages through the tests
    /// </summary>
    public static class Pages
    {

        public static Homepage Homepage
        {
            get
            {
                var homepage = new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
                PageFactory.InitElements(Browser.Driver, homepage);
                return homepage;
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage(Helper.LoginPage.AbsoluteUri, Helper.LoginPageTitle);
                PageFactory.InitElements(Browser.Driver, loginPage);
                return loginPage;
            }
        }

        public static NewsPage NewsPage
        {
            get
            {
                var newsPage = new NewsPage(Helper.NewsPage.AbsoluteUri, Helper.NewsPageTitle);
                PageFactory.InitElements(Browser.Driver, newsPage);
                return newsPage;
            }
        }

        public static ReadArticlePage ReadArticlePage
        {
            get
            {
                var articlePage = new ReadArticlePage(Helper.ReadArticlePage.AbsoluteUri, Helper.ReadArticlePageTitle);
                PageFactory.InitElements(Browser.Driver, articlePage);
                return articlePage;
            }
        }

        public static EditArticlePage EditArticlePage
        {
            get
            {
                var articlePage = new EditArticlePage(Helper.EditArticlePage.AbsoluteUri, Helper.EditArticlePageTitle);
                PageFactory.InitElements(Browser.Driver, articlePage);
                return articlePage;
            }
        }

        public static NewArticlePage NewArticlePage
        {
            get
            {
                var articlePage = new NewArticlePage(Helper.NewArticlePage.AbsoluteUri, Helper.NewArticlePageTitle);
                PageFactory.InitElements(Browser.Driver, articlePage);
                return articlePage;
            }
        }
    }
}
