namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using Machine.Specifications;
    using PageObjects;

    class HomepageSpec
    {
        [Subject("Employee User: Homepage")]
        public class When_user_lands_on_the_homepage : EmployeeUserContext
        {
            It Should_have_the_most_popular_news_chart_displayed =
                () => Pages.Homepage.MostPopularPanelExistsWithChart().ShouldBeTrue();

            It Should_have_the_latest_news_articles_displayed =
                () => Pages.Homepage.LatestNewsArticlesExist().ShouldBeTrue();

            It Should_have_the_correct_number_of_latest_articles_displayed =
                () => Pages.Homepage.GetNewsArticlesCount().ShouldEqual(Helper.HomepageLatestArticleCount);

            It Should_not_have_the_new_article_button_displayed =
                () => Pages.Homepage.IsNewArticleButtonVisible().ShouldBeFalse();
        }

        [Subject("Employee User: Navigation Bar")]
        public class When_the_user_clicks_the_home_button : EmployeeUserContext
        {
            Because Of = () => Pages.Homepage.ClickHome();

            It should_be_on_the_home_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.HomepageTitle);
        }

        [Subject("Employee User: Navigation Bar")]
        public class When_the_user_clicks_the_news_button : EmployeeUserContext
        {
            Because Of = () => Pages.Homepage.ClickNews();

            It should_be_on_the_news_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.NewsPageTitle);
        }

        [Subject("Employee User: Navigation Bar")]
        public class When_the_user_clicks_the_help_button : EmployeeUserContext
        {
            Because Of = () => Pages.Homepage.ClickHelp();

            It should_be_on_the_help_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.HelpPageTitle);
        }

        [Subject("Employee User: Navigation Bar")]
        public class When_the_user_clicks_the_contact_button : EmployeeUserContext
        {
            Because Of = () => Pages.Homepage.ClickContact();

            It should_be_on_the_contact_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.ContactPageTitle);
        }

        [Subject("Employee User: Navigation Bar")]
        public class When_the_user_clicks_the_logout_button : EmployeeUserContext
        {
            Because Of = () => Pages.Homepage.Logout();

            It should_be_on_the_login_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.LoginPageTitle);
        }
    }
}
