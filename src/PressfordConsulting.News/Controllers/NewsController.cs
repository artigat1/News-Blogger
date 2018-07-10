namespace PressfordConsulting.News.Controllers
{
    using System;
    using System.Web.Mvc;
    using Models;
    using Services;

    public class NewsController : Controller
    {
        /// <summary>
        /// The service to retrieve the articles
        /// </summary>
        readonly IArticleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewsController"/> class.
        /// </summary>
        /// <param name="service">The <see cref="IArticleService"/>.</param>
        public NewsController(IArticleService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            _service = service;
        }

        /// <summary>
        /// The inde method gets all news articles
        /// Must be authenticated to view this page.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the homepage page.</returns>
        [Authorize]
        public ActionResult Index()
        {
            NewsViewModel model = _service.GetAllArticles(User);

            return View(model);
        }
    }
}