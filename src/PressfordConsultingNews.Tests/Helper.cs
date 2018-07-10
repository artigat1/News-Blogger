namespace PressfordConsultingNews.Tests
{
    using System;

    /// <summary>
    /// Define some standard test variables for use in all tests
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Gets the username for testing.
        /// </summary>
        public static string Username { get { return "user@pressford.com"; }}

        /// <summary>
        /// Gets the article title for testing.
        /// </summary>
        public static string ArticleTitle { get { return "Test Article Title."; }}

        /// <summary>
        /// Gets the content of the article for testing.
        /// </summary>
        public static string ArticleContent { get { return "The quick brown fox jumps over the lazy dog."; }}

        /// <summary>
        /// Gets the article image for testing.
        /// </summary>
        public static string ArticleImage{get { return "http://example.test.org/image.png"; }}
    }
}
