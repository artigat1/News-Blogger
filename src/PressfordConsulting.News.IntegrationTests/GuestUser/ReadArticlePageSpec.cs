namespace PressfordConsulting.News.IntegrationTests.GuestUser
{
    using Machine.Specifications;
    using PageObjects;

    [Subject("Guest User: Read Article Page")]
    public class When_user_lands_on_the_read_article_page : GuestUserContext
    {
        Establish context = () => Pages.ReadArticlePage.GotoWithoutWait();

        It should_redirect_to_the_login_page =
            () => Pages.ReadArticlePage.GetPageTitle().ShouldEqual(Helper.LoginPageTitle);
    }
}

