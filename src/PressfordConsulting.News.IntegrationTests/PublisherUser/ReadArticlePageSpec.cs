namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the read article page
    /// </summary>
    public class ReadArticlePageSpec
    {
        public abstract class ReadArticleContext : PublisherUserContext
        {
            Establish context = () => Pages.ReadArticlePage.Goto();
        }

        [Subject("Publisher User: Read Article Page")]
        public class When_user_lands_on_the_read_article_page : ReadArticleContext
        {
            It should_display_the_article_title = () => Pages.ReadArticlePage.IsArticleTitleVisible().ShouldBeTrue();

            It should_display_the_article_author = () => Pages.ReadArticlePage.IsArticleAuthorVisible().ShouldBeTrue();

            It should_display_the_article_publish_date = () => Pages.ReadArticlePage.IsArticlePublishedDateVisible().ShouldBeTrue();

            It should_display_the_article_content = () => Pages.ReadArticlePage.IsArticleContentVisible().ShouldBeTrue();

            It should_display_the_main_action_button = () => Pages.ReadArticlePage.IsMainActionButtonVisible().ShouldBeTrue();
        }
    }
}
