namespace PressfordConsulting.News.IntegrationTests.PublisherUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Common context for all the publisher users
    /// </summary>
    public abstract class PublisherUserContext
    {
        Establish context = () =>
        {
            Browser.Open();
            Pages.LoginPage.Goto();
            Pages.LoginPage.Login(Helper.PublisherUsername, Helper.PublisherPassword);
        };

        Cleanup after = () => Browser.Quit();
    }
}
