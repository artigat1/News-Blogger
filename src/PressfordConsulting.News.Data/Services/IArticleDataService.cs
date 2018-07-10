namespace PressfordConsulting.News.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Resources;

    public interface IArticleDataService
    {
        /// <summary>
        /// Adds a new article.
        /// </summary>
        /// <param name="article">The <see cref="Article"/> to store.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task AddArticleAsync(Article article);

        /// <summary>
        /// Updates an existing article.
        /// </summary>
        /// <param name="article">The <see cref="Article"/> to store.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task UpdateArticleAsync(Article article);

        /// <summary>
        /// Deletes an existing article.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task DeleteArticleAsync(int id);

        /// <summary>
        /// Get the <see cref="Article"/> specified by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// The requested <see cref="Article" />.
        Article ReadArticle(int id);

        /// <summary>
        /// Gets all the current articles
        /// </summary>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article"/> entities.
        /// </returns>
        IEnumerable<Article> GetAllArticles();

        /// <summary>
        /// Gets the latest <paramref name="articleCount" /> articles
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article" /> 
        /// the latest <paramref name="articleCount"/> articles.
        /// </returns>
        IEnumerable<Article> GetLatestArticles(int articleCount);

        /// <summary>
        /// Gets the <paramref name="articleCount" /> articles with the most likes.
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="Article" /> 
        /// the latest <paramref name="articleCount"/> articles.
        /// </returns>
        IEnumerable<Article> GetMostPopularArticles(int articleCount);

        /// <summary>
        /// Likes the article specified by the <paramref name="like" />.
        /// </summary>
        /// <param name="like">The <see cref="ArticleLike"/>.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task LikeArticleAsync(ArticleLike like);

        /// <summary>
        /// Remove the article 'like' specified by the <paramref name="likeId" />.
        /// </summary>
        /// <param name="likeId">The id of the like to be removed.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task RemoveArticleLikeAsync(int likeId);

        /// <summary>
        /// Gets a count of how many likes, in total, the <paramref name="username"/> has made
        /// </summary>
        /// <param name="username">The id of the like to be removed.</param>
        /// <returns>
        /// The number of like for the <paramref name="username"/>
        /// </returns>
        int GetUserLikeCount(string username);
    }
}
