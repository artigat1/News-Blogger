namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the new article page
    /// </summary>
    public class NewArticlePageSpec
    {
        [Subject("Employee User: New Article Page")]
        public class When_user_lands_on_the_new_article_page : EmployeeUserContext
        {
            Establish context = () => Pages.NewArticlePage.GotoWithoutWait();

            It should_redirect_to_the_error_page =
                () => Pages.NewArticlePage.GetPageTitle().ShouldEqual(Helper.PermissionsErrorPageTitle);
        }
    }
}
