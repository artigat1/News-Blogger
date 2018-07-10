namespace PressfordConsulting.News.Data.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        public Article()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="author">The author.</param>
        /// <param name="publishDate">The publish date.</param>
        public Article(
            string title,
            string content,
            string author,
            DateTime publishDate)
        {
            if (title == null) throw new ArgumentNullException("title");
            if (content == null) throw new ArgumentNullException("content");
            if (author == null) throw new ArgumentNullException("author");

            Title = title;
            Content = content;
            Author = author;
            PublishDate = publishDate;
        }

        /// <summary>
        /// Gets or sets the article identifier.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the title of the article.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the html content of the article.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the article likes.
        /// </summary>
        public virtual ICollection<ArticleLike> Likes { get; set; }

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay
        {
            get { return string.Format("Article: {0} ({1})", Title, ArticleId); }
        }
    }
}
