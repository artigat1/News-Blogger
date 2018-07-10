namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the news page
    /// </summary>
    class NewsPageSpec
    {
        public abstract class NewsPageContext : PublisherUserContext
        {
            Establish context = () => Pages.NewsPage.Goto();
        }

        [Subject("Publisher User: News Page")]
        public class When_user_lands_on_the_news_page : NewsPageContext
        {
            It should_display_news_articles = () => Pages.NewsPage.GetNewsArticlesCount().ShouldBeGreaterThan(0);

            It should_display_the_add_article_button = () => Pages.NewsPage.IsNewArticleButtonVisible().ShouldBeTrue();
        }

        [Subject("Publisher User: News Page")]
        public class When_user_clicks_the_add_article_button : NewsPageContext
        {
            Because Of = () => Pages.NewsPage.ClickNewArticleButton();

            It should_display_the_add_article_page = () => Pages.NewsPage.GetPageTitle().ShouldContain("Article");
        }
    }
}
