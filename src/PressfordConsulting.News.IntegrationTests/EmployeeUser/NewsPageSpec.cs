namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using System.Runtime.InteropServices;
    using Machine.Specifications;
    using PageObjects;

    class NewsPageSpec
    {
        [Subject("Employee User: News Page")]
        public class When_user_lands_on_the_news_page : EmployeeUserContext
        {
            Establish context = () => Pages.NewsPage.GotoWithoutWait();

            It should_display_news_articles = () => Pages.NewsPage.GetNewsArticlesCount().ShouldBeGreaterThan(0);

            It should_not_display_the_add_article_button = () => Pages.NewsPage.IsNewArticleButtonVisible().ShouldBeFalse();
        }

        [Subject("Employee User: News Page")]
        public class When_user_clicks_read_more_link : EmployeeUserContext
        {
            private static ReadArticlePage _result;

            Establish context = () => Pages.NewsPage.GotoWithoutWait();

            Because of = () => _result = Pages.NewsPage.ReadFirstArticle();

            It should_display_the_read_article_page = () => _result.ShouldBeOfExactType<ReadArticlePage>();
        }
    }
}
