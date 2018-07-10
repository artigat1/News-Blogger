namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the edit article page
    /// </summary>
    public class NewArticlePageSpec
    {
        public abstract class NewArticleContext : PublisherUserContext
        {
            Establish context = () => Pages.NewArticlePage.Goto();
        }

        [Subject("Publisher User: New Article Page")]
        public class When_user_lands_on_the_new_article_page : NewArticleContext
        {
            It should_display_current_title_to_edit = () => Pages.NewArticlePage.GetTitle().ShouldBeEmpty();

            It should_display_current_content_to_edit = () => Pages.NewArticlePage.GetContent().ShouldBeEmpty();

            It should_display_current_image_to_edit = () => Pages.NewArticlePage.GetImage().ShouldBeEmpty();

            It should_display_the_add_button = () => Pages.NewArticlePage.IsAddButtonVisible().ShouldBeTrue();
        }

        [Subject("Publisher User: New Article Page")]
        public class When_user_creates_a_new_article : NewArticleContext
        {
            private const string Title = "New Article Title";
            private const string Content = "The quick brown fox jumps over the lazy dog.";
            private const string Image = "http://dummyimage.com/600x400/000/fff&text=Testing!";
            private static Homepage _result;

            Because of = () => _result = Pages.NewArticlePage.AddNewArticle(Title, Content, Image);

            It Should_return_to_the_homepage = () => _result.ShouldBeOfExactType<Homepage>();
        }

        [Subject("Publisher User: New Article Page")]
        public class When_user_hits_add_without_adding_article_data : NewArticleContext
        {
            private static NewArticlePage _result;

            Because of = () => _result = Pages.NewArticlePage.Submit();

            It Should_still_be_on_the_new_article_page = () => _result.ShouldBeOfExactType<NewArticlePage>();

            It Should_be_displaying_errors = () => Pages.NewArticlePage.HasErrors().ShouldBeTrue();
        }
    }
}
