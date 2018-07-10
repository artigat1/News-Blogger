namespace PressfordConsulting.News.Application
{
    using System;
    using Microsoft.Azure;

    public static class Settings
    {
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
            string setting = CloudConfigurationManager.GetSetting(name);
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
    }
}