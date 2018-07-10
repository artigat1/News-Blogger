namespace PressfordConsulting.News.IntegrationTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;

    public static class Browser
    {
        private static IWebDriver _webDriver;

        //Here we wrap the web driver properties and methods 

        internal static string Title
        {
            get { return _webDriver.Title; }
        }

        internal static string PageSource
        {
            get { return _webDriver.PageSource; }
        }

        internal static string Url
        {
            get { return _webDriver.Url; }
        }

        internal static ISearchContext Driver
        {
            get { return _webDriver; }
        }

        public static IWebDriver GetDriver { get; private set; }

        public static void Open()
        {
            GetDriver = GetNewDriver();
        }

        public static void Goto(string url)
        {
            _webDriver.Url = url;
        }

        internal static WebDriverWait Wait()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Quits the browser and all windows associated with it.
        /// </summary>
        public static void Quit()
        {
            _webDriver.Quit();
        }

        /// <summary>
        /// Maximises the browser window
        /// </summary>
        internal static void MaximizeWindow()
        {
            _webDriver.Manage().Window.Maximize();
        }

        internal static IWebDriver GetNewDriver()
        {
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driverService.IgnoreSslErrors = true;
            var newDriver = new PhantomJSDriver(driverService);
            _webDriver = newDriver;
            MaximizeWindow();

            return _webDriver;
        }
    }
}
