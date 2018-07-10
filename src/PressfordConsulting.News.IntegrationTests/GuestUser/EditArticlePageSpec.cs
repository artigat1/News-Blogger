namespace PressfordConsulting.News.IntegrationTests.GuestUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the edit article page
    /// </summary>
    public class EditArticlePageSpec
    {
        [Subject("Guest User: Edit Article Page")]
        public class When_user_lands_on_the_edit_article_page : GuestUserContext
        {
            Establish context = () => Pages.EditArticlePage.GotoWithoutWait();

            It should_redirect_to_the_login_page =
                () => Pages.ReadArticlePage.GetPageTitle().ShouldEqual(Helper.LoginPageTitle);
        }
    }
}
