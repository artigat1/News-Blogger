namespace PressfordConsulting.News.Application.Extensions
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class UrlExtensions
    {
        public static string AbsoluteUrl(this UrlHelper urlHelper, string action, string controller = null, object obj = null)
        {
            if (string.IsNullOrWhiteSpace(action)) throw new ArgumentNullException("action");

            string path = urlHelper.Action(action, controller, obj);
            if (path == null) return null;

            var url = new Uri(HttpContext.Current.Request.Url, path);
            return url.AbsoluteUri;
        }
    }
}