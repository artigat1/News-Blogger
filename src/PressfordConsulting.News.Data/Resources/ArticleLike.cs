namespace PressfordConsulting.News.Data.Resources
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ArticleLike
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleLike"/> class.
        /// </summary>
        public ArticleLike()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleLike"/> class.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <param name="username">The username.</param>
        public ArticleLike(int articleId, string username)
        {
            if(string.IsNullOrWhiteSpace(username)) 
                throw new ArgumentNullException("username");

            ArticleId = articleId;
            Username = username;
        }

        /// <summary>
        /// Gets or sets the like identifier.
        /// </summary>
        public int LikeId { get; set; }

        /// <summary>
        /// Gets or sets the username who is liking the article.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the article that is being liked.
        /// </summary>
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay
        {
            get { return string.Format("Liked by: {0}", Username); }
        }
    }
}
