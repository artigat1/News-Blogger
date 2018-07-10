namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    class HomepageSpec
    {
        [Subject("Publisher User: Homepage")]
        public class When_user_lands_on_the_homepage : PublisherUserContext
        {
            It Should_have_the_most_popular_news_chart_displayed =
                () => Pages.Homepage.MostPopularPanelExistsWithChart().ShouldBeTrue();

            It Should_have_the_latest_news_articles_displayed =
                () => Pages.Homepage.LatestNewsArticlesExist().ShouldBeTrue();

            It Should_have_the_correct_number_of_latest_articles_displayed =
                () => Pages.Homepage.GetNewsArticlesCount().ShouldEqual(Helper.HomepageLatestArticleCount);

            It Should_have_the_new_article_button_displayed =
                () => Pages.Homepage.IsNewArticleButtonVisible().ShouldBeTrue();
        }

        [Subject("Publisher User: HomePage")]
        public class When_user_clicks_the_add_article_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.ClickNewArticleButton();

            It should_display_the_add_article_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.NewArticlePageTitle);
        }

        [Subject("Publisher User: Navigation Bar")]
        public class When_the_user_clicks_the_home_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.ClickHome();

            It should_be_on_the_home_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.HomepageTitle);
        }

        [Subject("Publisher User: Navigation Bar")]
        public class When_the_user_clicks_the_news_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.ClickNews();

            It should_be_on_the_news_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.NewsPageTitle);
        }

        [Subject("Publisher User: Navigation Bar")]
        public class When_the_user_clicks_the_help_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.ClickHelp();

            It should_be_on_the_help_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.HelpPageTitle);
        }

        [Subject("Publisher User: Navigation Bar")]
        public class When_the_user_clicks_the_contact_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.ClickContact();

            It should_be_on_the_contact_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.ContactPageTitle);
        }

        [Subject("Publisher User: Navigation Bar")]
        public class When_the_user_clicks_the_logout_button : PublisherUserContext
        {
            Because Of = () => Pages.Homepage.Logout();

            It should_be_on_the_login_page = () => Pages.Homepage.GetPageTitle().ShouldEqual(Helper.LoginPageTitle);
        }
    }
}
