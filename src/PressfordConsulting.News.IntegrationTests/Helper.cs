namespace PressfordConsulting.News.IntegrationTests
{
    using System;
    using System.Configuration;

    public static class Helper
    {
        /// <summary>
        /// Gets the homepage <see cref="Uri"/>.
        /// </summary>
        public static Uri Homepage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.newspage"); }
        }

        /// <summary>
        /// Gets the title of the help page.
        /// </summary>
        public static string HelpPageTitle
        {
            get { return "Help | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the title of the error page.
        /// </summary>
        public static string ErrorPageTitle
        {
            get { return "Error"; }
        }

        /// <summary>
        /// Gets the title of the permissions error page.
        /// </summary>
        public static string PermissionsErrorPageTitle
        {
            get { return "Permissions Error"; }
        }

        /// <summary>
        /// Gets the title of the contact page.
        /// </summary>
        public static string ContactPageTitle
        {
            get { return "Contact us | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the title of the homepage.
        /// </summary>
        public static string HomepageTitle
        {
            get { return "Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the news page <see cref="Uri"/>.
        /// </summary>
        public static Uri NewsPage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.newspage"); }
        }

        /// <summary>
        /// Gets the title of the news page.
        /// </summary>
        public static string NewsPageTitle
        {
            get { return "News | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the login page <see cref="Uri"/>.
        /// </summary>
        public static Uri LoginPage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.loginpage"); }
        }

        /// <summary>
        /// Gets the title of the login page.
        /// </summary>
        public static string LoginPageTitle
        {
            get { return "Login | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the register page <see cref="Uri"/>.
        /// </summary>
        public static Uri RegisterPage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.registerpage"); }
        }

        /// <summary>
        /// Gets the title of the register page.
        /// </summary>
        public static string RegisterPageTitle
        {
            get { return "Register | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the read article page <see cref="Uri"/>.
        /// </summary>
        public static Uri ReadArticlePage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.readarticlepage"); }
        }

        /// <summary>
        /// Gets the title of the read article page.
        /// </summary>
        public static string ReadArticlePageTitle
        {
            get { return "Read Article | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the edit article page <see cref="Uri"/>.
        /// </summary>
        public static Uri EditArticlePage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.editarticlepage"); }
        }

        /// <summary>
        /// Gets the title of the edit article page.
        /// </summary>
        public static string EditArticlePageTitle
        {
            get { return "Edit Article | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the new article page <see cref="Uri"/>.
        /// </summary>
        public static Uri NewArticlePage
        {
            get { return GetSettingAsUri("pressfordconsulting.news.newarticlepage"); }
        }

        /// <summary>
        /// Gets the title of the new article page.
        /// </summary>
        public static string NewArticlePageTitle
        {
            get { return "New Article | Pressford Consulting"; }
        }

        /// <summary>
        /// Gets the valid employee username.
        /// </summary>
        public static string EmployeeUsername
        {
            get { return "employee@pressford.com"; }
        }

        /// <summary>
        /// Gets the valid employee password.
        /// </summary>
        public static string EmployeePassword
        {
            get { return "password"; }
        }

        /// <summary>
        /// Gets the valid publisher username.
        /// </summary>
        public static string PublisherUsername
        {
            get { return "publisher@pressford.com"; }
        }

        /// <summary>
        /// Gets the valid publisher password.
        /// </summary>
        public static string PublisherPassword
        {
            get { return "publisher"; }
        }

        /// <summary>
        /// Gets the maximum number of likes per user.
        /// </summary>
        public static int MaxNumberOfLikesPerUser
        {
            get { return GetSettingAsInt("MaxNumberOfLikesPerUser"); }
        }

        /// <summary>
        /// Gets the most popular articles count for the homepage.
        /// </summary>
        public static int MostPopularArticlesCount
        {
            get { return GetSettingAsInt("MostPopularArticlesCount"); }
        }

        /// <summary>
        /// Gets the homepage latest article count for the homepage.
        /// </summary>
        public static int HomepageLatestArticleCount
        {
            get { return GetSettingAsInt("HomepageLatestArticleCount"); }
        }

        /// <summary>
        /// Gets the setting from the configuration.
        /// </summary>
        /// <param name="name">The name of the setting to retrieve.</param>
        /// <returns>The setting value.</returns>
        private static string GetSetting(string name)
        {
            string setting = ConfigurationManager.AppSettings[name];
            return setting;
        }

        /// <summary>
        /// Gets the setting specified in <paramref name="name"/> as <see cref="int"/>.
        /// </summary>
        /// <param name="name">The name of the setting to retrieve.</param>
        /// <returns>The <see cref="int"/> setting value.</returns>
        private static int GetSettingAsInt(string name)
        {
            string setting = GetSetting(name);
            int val;
            if (!int.TryParse(setting, out val))
            {
                var message =
                    string.Format(
                        "Cannot convert {0} to an int. This is set in web.config as {1}",
                        setting,
                        name);
                throw new ArgumentException(message);
            }

            return val;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> for the setting with <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The <see cref="Uri"/> of the named setting.</returns>
        private static Uri GetSettingAsUri(string name)
        {
            var root = GetSetting("pressfordconsulting.news.root");
            var path = GetSetting(name);
            var uri = new Uri(new Uri(root), path);

            return uri;
        }
    }
}
