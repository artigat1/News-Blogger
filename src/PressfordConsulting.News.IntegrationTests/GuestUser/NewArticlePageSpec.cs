namespace PressfordConsulting.News.IntegrationTests.GuestUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the new article page
    /// </summary>
    public class NewArticlePageSpec
    {
        [Subject("Guest User: New Article Page")]
        public class When_user_lands_on_the_new_article_page : GuestUserContext
        {
            Establish context = () => Pages.NewArticlePage.GotoWithoutWait();

            It should_redirect_to_the_login_page =
                () => Pages.NewArticlePage.GetPageTitle().ShouldEqual(Helper.LoginPageTitle);
        }
    }
}
