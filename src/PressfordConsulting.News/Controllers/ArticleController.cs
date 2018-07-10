namespace PressfordConsulting.News.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Application;
    using Models;
    using Services;

    public class ArticleController : Controller
    {
        /// <summary>
        /// The service to retrieve the articles
        /// </summary>
        readonly IArticleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleController"/> class.
        /// </summary>
        /// <param name="service">The <see cref="IArticleService"/>.</param>
        public ArticleController(IArticleService service)
        {
            if (service == null) throw new ArgumentNullException("service");

            _service = service;
        }

        /// <summary>
        /// Gets the article specified by the <paramref name="id"/>.
        /// Must be authenticated to view this page.
        /// </summary>
        /// <param name="id">The article identifier.</param>
        /// <returns>The <see cref="ActionResult"/> for the read article page.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult Read(int id)
        {
            var model = _service.ReadArticle(id, User);

            return View(model);
        }

        /// <summary>
        /// Gets the page to create a new article.
        /// Must be authenticated and a Publisher to view this page.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the page to create a new article.</returns>
        [HttpGet]
        [Authorize(Roles = "Publisher")]
        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        /// Saves the new article
        /// Must be authenticated and Publisher to view this page.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel"/>.</param>
        /// <returns>A redirect <see cref="ActionResult"/> to the news page where the new article should be first.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Publisher")]
        public async Task<ActionResult> New(ArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.AddNewArticle(model, User);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Gets the page to edit an exiting article.
        /// Must be authenticated and a Publisher to view this page.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> for the page to edit an article.</returns>
        [HttpGet]
        [Authorize(Roles = "Publisher")]
        public ActionResult Edit(int id)
        {
            var model = _service.ReadArticle(id, User);

            return View(model);
        }

        /// <summary>
        /// Edits the specified article
        /// Must be authenticated and a Publisher to view this page.
        /// </summary>
        /// <param name="model">The <see cref="ArticleViewModel"/>.</param>
        /// <returns>A redirect <see cref="ActionResult"/> to the article's read page.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Publisher")]
        public async Task<ActionResult> Edit(ArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _service.UpdateArticleAsync(model, User);

            return RedirectToAction("Read", new { id = @model.Id });
        }

        /// <summary>
        /// Deletes the article specified by <paramref name="id"/>
        /// Must be authenticated and a Publisher to view this page.
        /// </summary>
        /// <param name="id">The identifier of the article to delete.</param>
        /// <returns>A redirect <see cref="ActionResult"/> to the news page where the deleted article is no longer visible.</returns>
        [HttpGet]
        [Authorize(Roles = "Publisher")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteArticleAsync(id);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Lets a user like the article <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The article identifier.</param>
        /// <returns><see cref="JsonResult"/> with the outcome of the request.</returns>
        [HttpGet]
        [Authorize]
        public JsonResult Like(int id)
        {
            try
            {
                var userCanLike = _service.IsUserAllowedToLike(User);
                if (userCanLike)
                {
                    _service.LikeArticleAsync(id, User);
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

                var errorMessage = string.Format(
                    "You can like a maximum of {0} articles. " +
                    "You need to un-like an article before you can like this one.",
                    Settings.MaxNumberOfLikesPerUser);
                return Json(new { success = false, error = errorMessage }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Lets a user remove their like from the article <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The article identifier.</param>
        /// <returns><see cref="JsonResult"/> with the outcome of the request.</returns>
        [HttpGet]
        [Authorize]
        public JsonResult DisLike(int id)
        {
            try
            {
                _service.RemoveArticleLikeAsync(id, User);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}