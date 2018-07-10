namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the edit article page
    /// </summary>
    public class EditArticlePageSpec
    {
        [Subject("Employee User: Read Article Page")]
        public class When_user_lands_on_the_edit_article_page : EmployeeUserContext
        {
            Establish context = () => Pages.EditArticlePage.GotoWithoutWait();

            It should_redirect_to_the_error_page =
                () => Pages.ReadArticlePage.GetPageTitle().ShouldEqual(Helper.PermissionsErrorPageTitle);
        }
    }
}
