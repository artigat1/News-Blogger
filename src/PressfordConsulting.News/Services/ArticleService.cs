namespace PressfordConsulting.News.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Application;
    using Data.Resources;
    using Data.Services;
    using Microsoft.AspNet.Identity;
    using Models;

    /// <summary>
    /// Service to connect articles to the data store.
    /// </summary>
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// The article data service to connect to the data store
        /// </summary>
        readonly IArticleDataService _articleDataService;

        public ArticleService(IArticleDataService dataService)
        {
            if (dataService == null) throw new ArgumentNullException("dataService");

            _articleDataService = dataService;
        }

        /// <summary>
        /// Adds a new article using the <see cref="ArticleDataService" />.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel" /> to store.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task AddNewArticle(ArticleViewModel model, IPrincipal user)
        {
            if (model == null) throw new ArgumentNullException("model");

            var article = ConvertToArticle(model, user.Identity.GetUserName());

            await _articleDataService.AddArticleAsync(article);
        }

        /// <summary>
        /// Updates an existing article.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel" /> to store.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task UpdateArticleAsync(ArticleViewModel model, IPrincipal user)
        {
            if (model == null) throw new ArgumentNullException("model");

            var article = ConvertToArticle(model, user.Identity.GetUserName());
            await _articleDataService.UpdateArticleAsync(article);
        }

        /// <summary>
        /// Deletes an existing article.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task DeleteArticleAsync(int id)
        {
            await _articleDataService.DeleteArticleAsync(id);
        }

        /// <summary>
        /// Gets all the current articles using the <see cref="ArticleDataService" />. 
        /// </summary>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> 
        /// of <see cref="ArticleViewModel"/> entities.
        /// </returns>
        public NewsViewModel GetAllArticles(IPrincipal user)
        {
            var model = new NewsViewModel
            {
                Articles = GetArticles(ArticleType.All, 0, user.Identity.GetUserName()),
            };

            return model;
        }

        /// <summary>
        /// Gets the latest <paramref name="articleCount" /> articles
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel"/> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel"/> entities..
        /// </returns>
        public NewsViewModel GetLatestArticles(int articleCount, IPrincipal user)
        {
            var model = new NewsViewModel
            {
                LatestArticles =
                    GetArticles(ArticleType.Latest, articleCount, user.Identity.GetUserName()),
            };

            return model;
        }

        /// <summary>
        /// Gets the <paramref name="articleCount" /> articles with the most likes.
        /// </summary>
        /// <param name="articleCount">The number of articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel" /> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel" /> entities..
        /// </returns>
        public NewsViewModel GetMostPopularArticles(int articleCount, IPrincipal user)
        {
            var model = new NewsViewModel
            {
                MostPopularArticles =
                    GetArticles(ArticleType.MostPopular, articleCount, user.Identity.GetUserName()),
            };

            return model;
        }

        /// <summary>
        /// Gets the articles needed for the homepage.
        /// </summary>
        /// <param name="latestArticleCount">The number of latest articles to return.</param>
        /// <param name="popularArticleCount">The number of most popular articles to return.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="NewsViewModel" /> containing a <see cref="Task{TEntity}" /> 7
        /// of <see cref="ArticleViewModel" /> entities..
        /// </returns>
        public NewsViewModel GetHomepageArticles(
            int latestArticleCount, 
            int popularArticleCount, 
            IPrincipal user)
        {
            var username = user.Identity.GetUserName();
            var model = new NewsViewModel
            {
                MostPopularArticles =
                    GetArticles(ArticleType.MostPopular, popularArticleCount, username),
                LatestArticles =
                    GetArticles(ArticleType.Latest, latestArticleCount, username),
            };
            model.ChartData = GetPieChartData(model.MostPopularArticles);

            return model;
        }

        /// <summary>
        /// Get the <see cref="ArticleViewModel" /> specified by <paramref name="id" /> using the <see cref="ArticleDataService" />.
        /// </summary>
        /// <param name="id">The article's identifier.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>The requested <see cref="ArticleViewModel" />.</returns>
        public ArticleViewModel ReadArticle(int id, IPrincipal user)
        {
            var article = _articleDataService.ReadArticle(id);
            return ConvertToArticleViewModel(article, user.Identity.GetUserName());
        }

        /// <summary>
        /// Determines whether a <paramref name="user"/> allowed to like articles.
        /// Each user can like a maximum of 5 articles.
        /// </summary>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns><c>true</c> if user has liked less than 5 articles, <c>false</c> otherwise</returns>
        public bool IsUserAllowedToLike(IPrincipal user)
        {
            if (user == null) 
                throw new ArgumentNullException("user");

            var username = user.Identity.GetUserName();
            var likeCountForUser = _articleDataService.GetUserLikeCount(username);
            return likeCountForUser <= Settings.MaxNumberOfLikesPerUser;
        }

        /// <summary>
        /// Likes the article specified by the <paramref name="id" />.
        /// Checks to see if user has already liked the article. 
        /// Cannot like an article more than once.
        /// </summary>
        /// <param name="id">The article identifier.</param>
        /// <param name="user">The current logged in user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task LikeArticleAsync(int id, IPrincipal user)
        {
            if (user == null) throw new ArgumentNullException("user");
            
            var username = user.Identity.GetUserName();
            var article = _articleDataService.ReadArticle(id);
            if (article == null)
            {
                var message = string.Format("The article ({0}) cannot be retrieved.", id);
                throw new NullReferenceException(message);
            }

            var userAlreadyLiked = article.Likes.SingleOrDefault(x => x.Username == username);
            if (userAlreadyLiked == null)
            {
                var articleLike = new ArticleLike(id, username);
                await _articleDataService.LikeArticleAsync(articleLike);
            }
        }

        /// <summary>
        /// Remove the like for the current user from the specified <paramref name="articleId" />.
        /// </summary>
        /// <param name="articleId">The identifier of the article to have the like removed.</param>
        /// <param name="user">The currently logged in <see cref="IPrincipal"/> user.</param>
        /// <returns>
        /// A <see cref="Task" /> that represents the asynchronous operation.
        /// </returns>
        public async Task RemoveArticleLikeAsync(int articleId, IPrincipal user)
        {
            var article = _articleDataService.ReadArticle(articleId);
            var like = (article.Likes.Where(x => x.Username == user.Identity.GetUserName())).FirstOrDefault();
            if (like != null)
            {
                await _articleDataService.RemoveArticleLikeAsync(like.LikeId);
            }
        }

        /// <summary>
        /// Converts to <see cref="Article"/> to an <see cref="ArticleViewModel"/>.
        /// </summary>
        /// <param name="article">The <see cref="Article"/>.</param>
        /// <param name="username">The current logged in user.</param>
        /// <returns>The converted <see cref="ArticleViewModel"/>.</returns>
        public static ArticleViewModel ConvertToArticleViewModel(Article article, string username)
        {
            if (article == null)
            {
                return new ArticleViewModel();
            }

            var model =
                new ArticleViewModel(article.Title, article.Content, article.Author, article.PublishDate)
                {
                    Id = article.ArticleId,
                };

            if (article.Image != null)
            {
                model.Image = new Uri(article.Image);
            }

            if (article.Likes == null)
            {
                return model;
            }

            model.LikeCount = article.Likes.Count;
            model.UserLikesArticle =
                (article.Likes.Where(x => x.Username == username)).Any();

            return model;
        }

        /// <summary>
        /// Converts to <see cref="ArticleViewModel" /> to an <see cref="Article" />.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel" />.</param>
        /// <param name="username">The current logged in user.</param>
        /// <returns>
        /// The converted <see cref="Article" />.
        /// </returns>
        public static Article ConvertToArticle(ArticleViewModel model, string username)
        {
            if (model == null)
            {
                return new Article();
            }

            var article =
                new Article(model.Title, model.Content, username, DateTime.Now)
                {
                    ArticleId = model.Id,
                    Author = username
                };

            if (model.Image != null)
            {
                article.Image = model.Image.AbsoluteUri;
            }

            return article;
        }

        /// <summary>
        /// Wrapper method to get the different types of articles.
        /// </summary>
        /// <param name="type">The <see cref="ArticleType"/>.</param>
        /// <param name="articleCount">The article count.</param>
        /// <param name="username">The current logged in user.</param>
        /// <returns>
        /// A <see cref="IEnumerable{TEntity}" /> of <see cref="ArticleViewModel" /> 
        /// </returns>
        public IList<ArticleViewModel> GetArticles(ArticleType type, int articleCount, string username)
        {
            IEnumerable<Article> articles;
            switch (type)
            {
                case ArticleType.Latest:
                    articles = _articleDataService.GetLatestArticles(articleCount);
                    break;

                case ArticleType.MostPopular:
                    articles = _articleDataService.GetMostPopularArticles(articleCount);
                    break;

                default:
                    articles = _articleDataService.GetAllArticles();
                    break;
            }

            var articleList = articles as IList<Article> ?? articles.ToList();

            return articleList.Any() ? articleList.Select(x => ConvertToArticleViewModel(x, username)).ToList() : null;
        }

        /// <summary>
        /// Gets the the article data formatted for a pie chart.
        /// </summary>
        /// <param name="articles">The <see cref="Article"/> list.</param>
        /// <returns>The javascript string to add to the page for Chart.js.</returns>
        public static string GetPieChartData(IList<ArticleViewModel> articles)
        {
			if(articles == null || !articles.Any())
			{
				return string.Empty;
			}
			
            // Colours for the chart segments
            var colors = 
                new[]{"#004d40","#00695c","#00796b","#00897b","#009688","#26a69a","#4db6ac","#80cbc4","#b2dfdb","#e0f2f1"};

            var colorIdx = 0;
            var segments = new string[articles.Count()];
            foreach (ArticleViewModel article in articles)
            {
                segments[colorIdx] = string.Format(
                    "{{" +
                    "value: {0}," +
                    "color: '{1}'," +
                    "highlight: '#1de9b6'," +
                    "label: '{2}'," +
                    "articleId: '{3}'" +
                    "}}",
                    article.LikeCount,
                    colors[colorIdx],
                    article.Title,
                    article.Id);

                colorIdx++;
            }

            return string.Join(", ", segments);
        }

        /// <summary>
        /// The types of article that can be retrieved
        /// </summary>
        public enum ArticleType
        {
            All,
            Latest,
            MostPopular,
        }
    }
}