namespace PressfordConsulting.News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ArticleViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleViewModel"/> class.
        /// </summary>
        public ArticleViewModel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleViewModel" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="content">The content.</param>
        /// <param name="author">The author.</param>
        /// <param name="publishDate">The publish date.</param>
        /// <param name="likeCount">The number of likes the article has received (defaults to 0).</param>
        public ArticleViewModel(string title, string content, string author, DateTime publishDate, int likeCount = 0)
        {
            if (title == null) throw new ArgumentNullException("title");
            if (content == null) throw new ArgumentNullException("content");
            if (author == null) throw new ArgumentNullException("author");

            Title = title;
            Content = content;
            Author = author;
            PublishDate = publishDate;
            LikeCount = likeCount;
            UserLikesArticle = false;
        }

        /// <summary>
        /// Gets or sets the article's identifier.
        /// </summary>
        [HiddenInput]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the article.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the html content of the article.
        /// </summary>
        [Required]
        [AllowHtml]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the image for the article.
        /// </summary>
        [Display(Name = "Image url")]
        [DataType(DataType.Url)]
        public Uri Image { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the number of likes the article has received.
        /// </summary>
        [Editable(false)]
        public int LikeCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user likes article].
        /// </summary>
        /// <value>
        ///   <c>true</c> if the user likes article; otherwise, <c>false</c>.
        /// </value>
        [Editable(false)]
        public bool UserLikesArticle { get; set; }

        /// <summary>
        /// Gets the text from the first paragraph of the content.
        /// </summary>
        [Editable(false)]
        public string FirstParagraphText
        {
            get
            {
                Match m = Regex.Match(Content, @"<p>(.*?)</p>");
                return m.Success ? m.Groups[1].Value : Content;
            }
        }

        /// <summary>
        /// Gets the display value to show in the debugger.
        /// </summary>
        // ReSharper disable once UnusedMember.Local
        private string DebuggerDisplay
        {
            get { return string.Format("Article: {0} ({1})", Title, PublishDate); }
        }
    }
}