namespace PressfordConsulting.News.Controllers
{
    using System;
    using System.Web.Mvc;
    using Application;
    using Models;
    using Services;

    public class HomeController : Controller
    {
        /// <summary>
        /// The service to retrieve the articles
        /// </summary>
        readonly IArticleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="service">The <see cref="IArticleService"/>.</param>
        public HomeController(IArticleService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            _service = service;
        }

        /// <summary>
        /// The homepage method. Gets all news articles
        /// Must be authenticated to view this page.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the homepage page.</returns>
        [Authorize]
        public ActionResult Index()
        {
            NewsViewModel model = _service.GetHomepageArticles(
                Settings.HomepageLatestArticleCount, 
                Settings.MostPopularArticlesCount,
                User);

            return View(model);
        }

        /// <summary>
        /// The Help page
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the help page.</returns>
        [HttpGet]
        public ActionResult Help()
        {
            return View();
        }

        /// <summary>
        /// The Contact page
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the contact page.</returns>
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}