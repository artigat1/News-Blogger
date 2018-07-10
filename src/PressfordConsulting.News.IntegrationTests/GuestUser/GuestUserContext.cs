namespace PressfordConsulting.News.IntegrationTests.GuestUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Common context for all the guest users
    /// </summary>
    public abstract class GuestUserContext
    {
        Establish context = () => Browser.Open();

        Cleanup after = () => Browser.Quit();
    }
}
