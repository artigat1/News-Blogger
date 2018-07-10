namespace PressfordConsulting.News.IntegrationTests.EmployeeUser
{
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Common context for all the employee users
    /// </summary>
    public abstract class EmployeeUserContext
    {
        Establish context = () =>
        {
            Browser.Open();
            Pages.LoginPage.Goto();
            Pages.LoginPage.Login(Helper.EmployeeUsername, Helper.EmployeePassword);
        };

        Cleanup after = () => Browser.Quit();
    }
}
