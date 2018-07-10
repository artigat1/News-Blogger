namespace PressfordConsulting.News.Services
{
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Interface for <see cref="ArticleService"/>
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Adds a new article.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel" /> to store.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task AddNewArticle(ArticleViewModel model, IPrincipal user);

        /// <summary>
        /// Updates an existing article.
        /// </summary>
        /// <param name="article">The <see cref="ArticleViewModel"/> to store.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task UpdateArticleAsync(ArticleViewModel article, IPrincipal user);

        /// <summary>
        /// Deletes an existing article.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task DeleteArticleAsync(int id);

        /// <summary>
        /// Gets all the current articles
        /// </summary>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> of <see cref="ArticleViewModel"/> entities.
        /// </returns>
        NewsViewModel GetAllArticles(IPrincipal user);
        
        /// <summary>
        /// Gets the latest <paramref name="articleCount" /> articles
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel"/> entities..
        /// </returns>
        NewsViewModel GetLatestArticles(int articleCount, IPrincipal user);

        /// <summary>
        /// Gets the <paramref name="articleCount" /> articles with the most likes.
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel"/> entities..
        /// </returns>
        NewsViewModel GetMostPopularArticles(int articleCount, IPrincipal user);

        /// <summary>
        /// Gets the articles required for the homepage.
        /// </summary>
        /// <param name="latestArticleCount">The number of latest articles to return.</param>
        /// <param name="popularArticleCount">The number of most popular articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel"/> entities..
        /// </returns>
        NewsViewModel GetHomepageArticles(int latestArticleCount, int popularArticleCount, IPrincipal user);

        /// <summary>
        /// Get the <see cref="ArticleViewModel"/> specified by <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>The requested <see cref="ArticleViewModel" />.</returns>
        ArticleViewModel ReadArticle(int id, IPrincipal user);

        /// <summary>
        /// Determines whether a <paramref name="user"/> allowed to like articles.
        /// Each user can like a maximum of 5 articles.
        /// </summary>
        /// <param name="user">The username.</param>
        /// <returns><c>true</c> if user has liked less than 5 articles, <c>false</c> otherwise</returns>
        bool IsUserAllowedToLike(IPrincipal user);

        /// <summary>
        /// Likes the article specified by the <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The article identifier.</param>
        /// <param name="user">The current logged in user.</param>
        /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
        Task LikeArticleAsync(int id, IPrincipal user);

        /// <summary>
        /// Remove the article 'like' specified by the <paramref name="likeId" />.
        /// </summary>
        /// <param name="likeId">The id of the like to be removed.</param>
        /// <param name="user">The current logged in user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        Task RemoveArticleLikeAsync(int likeId, IPrincipal user);
    }
}