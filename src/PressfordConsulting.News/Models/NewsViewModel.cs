namespace PressfordConsulting.News.Models
{
    using System.Collections.Generic;

    public class NewsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsViewModel"/> class.
        /// </summary>
        public NewsViewModel()
        {
            Articles = new List<ArticleViewModel>();
            LatestArticles = new List<ArticleViewModel>();
            MostPopularArticles = new List<ArticleViewModel>();
        }

        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        public IList<ArticleViewModel> Articles { get; set; }

        /// <summary>
        /// Gets or sets the latest articles.
        /// </summary>
        public IList<ArticleViewModel> LatestArticles { get; set; }

        /// <summary>
        /// Gets or sets the most popular articles.
        /// </summary>
        public IList<ArticleViewModel> MostPopularArticles { get; set; }

        /// <summary>
        /// Gets or sets the chart data.
        /// </summary>
        public string ChartData { get; set; }
    }
}