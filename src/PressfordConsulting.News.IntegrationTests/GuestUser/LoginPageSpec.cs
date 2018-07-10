namespace PressfordConsulting.News.IntegrationTests.GuestUser
{
    using System.Linq;
    using Machine.Specifications;
    using PageObjects;

    /// <summary>
    /// Tests for the Login page
    /// </summary>
    public class LoginPageSpec
    {
        public abstract class LoginContext : GuestUserContext
        {
            Establish context = () => Pages.LoginPage.Goto();
        }

        [Subject("Guest User: Login Page")]
        public class When_the_user_enters_invalid_login_details : LoginContext
        {
            Because Of = () => Pages.LoginPage.Login("username@test.com", "password");

            It should_have_an_invalid_login_attempt_error =
                () => Pages.LoginPage.GetErrors().FirstOrDefault().ShouldEqual("Invalid login attempt.");
        }

        [Subject("Guest User: Login Page")]
        public class When_the_user_clicks_submit_without_entering_details : LoginContext
        {
            Because Of = () => Pages.LoginPage.ClickSubmit();

            It should_have_email_validation_error = () =>
            {
                var exists = from x in Pages.LoginPage.GetValidationErrors()
                             where x == "The Email field is required."
                             select x;
                exists.Any().ShouldBeTrue();
            };

            It should_have_password_validation_error = () =>
            {
                var exists = from x in Pages.LoginPage.GetValidationErrors()
                             where x == "The Password field is required."
                             select x;
                exists.Any().ShouldBeTrue();
            };
        }

        [Subject("Guest User: Login Page")]
        public class When_the_user_enters_valid_login_details : LoginContext
        {
            static Homepage _result;

            Because Of = () => _result = Pages.LoginPage.Login(Helper.EmployeeUsername, Helper.EmployeePassword);

            It should_display_the_homepage = () => _result.ShouldBeOfExactType<Homepage>();
        }
    }
}
