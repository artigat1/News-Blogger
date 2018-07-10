namespace PressfordConsulting.News.IntegrationTests.PageObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class LoginPage : Page
    {
        /// <summary>
        /// The email input box
        /// </summary>
        [FindsBy(How = How.Id, Using = "Email")]
        IWebElement InputEmail { get; set; }

        /// <summary>
        /// The password input box
        /// </summary>
        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement InputPassword { get; set; }

        /// <summary>
        /// The submit button
        /// </summary>
        [FindsBy(How = How.Name, Using = "action")]
        IWebElement SubmitButton { get; set; }

        /// <summary>
        /// The validation errors
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".validation-summary-errors li")]
        IList<IWebElement> ValidationErrors { get; set; }

        /// <summary>
        /// The validation errors
        /// </summary>
        [FindsBy(How = How.CssSelector, Using = ".field-validation-error span")]
        IList<IWebElement> FieldValidationErrors { get; set; }

        /// <summary>
        /// The Register navigation button
        /// </summary>
        [FindsBy(How = How.Id, Using = "registerLink")]
        IWebElement RegisterButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="url">The page URL.</param>
        /// <param name="pageTitle">The page title.</param>
        public LoginPage(string url, string pageTitle)
            : base(url, pageTitle)
        {
        }

        /// <summary>
        /// Performs the login using the <paramref name="username"/> & <paramref name="password"/>
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public Homepage Login(string username, string password)
        {
            WaitForLoad();

            InputEmail.Clear();
            InputEmail.SendKeys(username);

            InputPassword.Clear();
            InputPassword.SendKeys(password);

            SubmitButton.Click();

            return new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
        }

        /// <summary>
        /// Clicks the submit button.
        /// </summary>
        /// <returns>The expected <see cref="Homepage"/> that should result from this action.</returns>
        public Homepage ClickSubmit()
        {
            WaitForLoad();

            SubmitButton.Click();

            return new Homepage(Helper.Homepage.AbsoluteUri, Helper.HomepageTitle);
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <returns>The errors from the page as a <see cref="List{TEntity}"/> of <see cref="string"/> entities.</returns>
        public List<string> GetErrors()
        {
            var errors = ValidationErrors.Select(err => err.Text).ToList();
            return errors;
        }

        /// <summary>
        /// Gets the field validation errors.
        /// </summary>
        /// <returns>The errors from the page as a <see cref="List{TEntity}"/> of <see cref="string"/> entities.</returns>
        public List<string> GetValidationErrors()
        {
            var errors = FieldValidationErrors.Select(err => err.Text).ToList();
            return errors;
        }

        /// <summary>
        /// Clicks the register navigation button.
        /// </summary>
        public void ClickRegister()
        {
            WaitForLoad();

            RegisterButton.Click();
        }
    }
}
