namespace PressfordConsulting.News.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using log4net;
    using Resources;

    /// <summary>
    /// Implementation of <see cref="IArticleDataService"/> using Entity Framework and SQL Server
    /// </summary>
    public class ArticleDataService : IArticleDataService
    {
        /// <summary>
        /// The article context
        /// </summary>
        readonly NewsAppContext _context;

        /// <summary>
        /// The logger
        /// </summary>
        readonly ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleDataService"/> class.
        /// </summary>
        public ArticleDataService()
        {
            _context = new NewsAppContext();
            _logger = LogManager.GetLogger("ArticleDataService");
        }

        /// <summary>
        /// Adds a new article to the database.
        /// </summary>
        /// <param name="article">The <see cref="Article" /> to store.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task AddArticleAsync(Article article)
        {
            if (article == null) throw new ArgumentNullException("article");

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing article in the database.
        /// </summary>
        /// <param name="model">The <see cref="Article" /> to store.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task UpdateArticleAsync(Article model)
        {
            if (model == null) throw new ArgumentNullException("model");

            var article = _context.Articles.SingleOrDefault(x => x.ArticleId == model.ArticleId);
            if (article == null)
            {
                var message = string.Format("The article ({0}) cannot be retrieved.", model.ArticleId);
                throw new NullReferenceException(message);
            }

            _context.Entry(article).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an existing article from the database.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task DeleteArticleAsync(int id)
        {
            var article = _context.Articles.SingleOrDefault(x => x.ArticleId == id);
            if (article == null)
            {
                var message = string.Format("The article ({0}) cannot be retrieved.", id);
                throw new NullReferenceException(message);
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get the <see cref="Article" /> specified by <paramref name="id" /> from the database.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <returns>
        /// The requested <see cref="Article" />.
        /// </returns>
        public Article ReadArticle(int id)
        {
            var article = _context.Articles.SingleOrDefault(x => x.ArticleId == id);
            if (article != null)
            {
                return article;
            }

            var message = string.Format("The article ({0}) cannot be retrieved.", id);
            throw new NullReferenceException(message);
        }

        /// <summary>
        /// Gets all the current articles from the database
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article" /> entities.
        /// </returns>
        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.OrderByDescending(x => x.PublishDate).ToList();
        }

        /// <summary>
        /// Gets the latest <paramref name="articleCount" /> articles from the database
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article" /> 
        /// the latest <paramref name="articleCount"/> articles.
        /// </returns>
        public IEnumerable<Article> GetLatestArticles(int articleCount)
        {
            return _context.Articles
                .OrderByDescending(x => x.PublishDate)
                .Take(articleCount)
                .ToList();
        }

        /// <summary>
        /// Gets the <paramref name="articleCount" /> articles with the most likes.
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article" />
        /// the latest <paramref name="articleCount" /> articles.
        /// </returns>
        public IEnumerable<Article> GetMostPopularArticles(int articleCount)
        {
            return _context.Articles
                .OrderByDescending(x => x.Likes.Count)
                .Take(articleCount)
                .ToList();
        }

        /// <summary>
        /// Likes the article specified by the <paramref name="like" /> in the database.
        /// </summary>
        /// <param name="like">The <see cref="ArticleLike"/>.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task LikeArticleAsync(ArticleLike like)
        {
            if (like == null) throw new ArgumentNullException("like");

            _context.ArticleLikes.Add(like);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove the article 'like' specified by the <paramref name="likeId" /> from the database.
        /// </summary>
        /// <param name="likeId">The id of the like to be removed.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task RemoveArticleLikeAsync(int likeId)
        {
            var like = _context.ArticleLikes.SingleOrDefault(x => x.LikeId == likeId);
            if (like == null)
            {
                _logger.DebugFormat("Couldn't retrieve article like with id: {0}", likeId);
                return;
            }

            _context.ArticleLikes.Remove(like);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a count of how many likes, in total, the <paramref name="username" /> has made
        /// </summary>
        /// <param name="username">The id of the like to be removed.</param>
        /// <returns>
        /// The number of like for the <paramref name="username" />
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int GetUserLikeCount(string username)
        {
            var likes = _context.ArticleLikes.Count(x => x.Username == username);

            return likes;
        }
    }
}
