namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using Machine.Specifications;
    using PageObjects;

    public class ReadArticlePageSpec
    {
        public abstract class ReadArticleContext : EmployeeUserContext
        {
            Establish context = () => Pages.ReadArticlePage.Goto();
        }

        [Subject("Employee User: Read Article Page")]
        public class When_user_lands_on_the_read_article_page : ReadArticleContext
        {
            It should_display_the_article_title = () => Pages.ReadArticlePage.IsArticleTitleVisible().ShouldBeTrue();

            It should_display_the_article_author = () => Pages.ReadArticlePage.IsArticleAuthorVisible().ShouldBeTrue();

            It should_display_the_article_publish_date = () => Pages.ReadArticlePage.IsArticlePublishedDateVisible().ShouldBeTrue();

            It should_display_the_article_content = () => Pages.ReadArticlePage.IsArticleContentVisible().ShouldBeTrue();

            It should_not_display_the_main_action_button = () => Pages.ReadArticlePage.IsMainActionButtonVisible().ShouldBeFalse();
        }
    }
}
