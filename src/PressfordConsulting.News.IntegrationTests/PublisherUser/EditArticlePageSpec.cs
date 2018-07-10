namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the edit article page
    /// </summary>
    public class EditArticlePageSpec
    {
        public abstract class EditArticleContext : PublisherUserContext
        {
            Establish context = () => Pages.EditArticlePage.Goto();
        }

        [Subject("Publisher User: Edit Article Page")]
        public class When_user_lands_on_the_edit_article_page : EditArticleContext
        {
            It should_display_current_title_to_edit = () => Pages.EditArticlePage.GetTitle().ShouldNotBeEmpty();

            It should_display_current_content_to_edit = () => Pages.EditArticlePage.GetContent().ShouldNotBeEmpty();

            It should_display_the_update_button = () => Pages.EditArticlePage.IsUpdateButtonVisible().ShouldBeTrue();

            It should_display_the_current_image_to_edit = () => Pages.EditArticlePage.GetImage().ShouldNotBeEmpty();
        }

        [Subject("Publisher User: Edit Article Page")]
        public class When_user_edits_an_article : EditArticleContext
        {
            private const string Title = "New Article Title";
            private const string Content = "The quick brown fox jumps over the lazy dog.";
            private const string Image = "http://dummyimage.com/600x400/000/fff&text=Testing!";
            private static Homepage _result;

            Because of = () => _result = Pages.EditArticlePage.UpdateArticle(Title, Content, Image);

            It Should_return_to_the_homepage = () => _result.ShouldBeOfExactType<Homepage>();
        }

        [Subject("Publisher User: Edit Article Page")]
        public class When_user_edits_an_article_and_removes_all_content : EditArticleContext
        {
            private static EditArticlePage _result;

            Because of = () => _result = Pages.EditArticlePage.RemoveContentAndSubmit();

            It Should_still_be_on_the_edit_article_page = () => _result.ShouldBeOfExactType<EditArticlePage>();

            It Should_be_displaying_errors = () => Pages.EditArticlePage.HasErrors().ShouldBeTrue();
        }
    }
}
