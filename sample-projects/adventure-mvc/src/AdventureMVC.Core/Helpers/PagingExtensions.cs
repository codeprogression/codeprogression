using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventureMVC.Core.Helpers
{
    //http://blogs.taiga.nl/martijn/2008/08/27/paging-with-asp.net-mvc
    public static class PagingExtensions
    {
        #region HtmlHelper extensions

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, null);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, null);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, object values)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, new RouteValueDictionary(values));
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, object values)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, actionName, new RouteValueDictionary(values));
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, RouteValueDictionary valuesDictionary)
        {
            return Pager(htmlHelper, pageSize, currentPage, totalItemCount, null, valuesDictionary);
        }

        public static string Pager(this HtmlHelper htmlHelper, int pageSize, int currentPage, int totalItemCount, string actionName, RouteValueDictionary valuesDictionary)
        {
            if (valuesDictionary == null)
            {
                valuesDictionary = new RouteValueDictionary();
            }
            if (actionName != null)
            {
                if (valuesDictionary.ContainsKey("action"))
                {
                    throw new ArgumentException("The valuesDictionary already contains an action.", "actionName");
                }
                valuesDictionary.Add("action", actionName);
            }
            var pager = new Pager(htmlHelper.ViewContext, pageSize, currentPage, totalItemCount, valuesDictionary);
            return pager.RenderHtml();
        }

        #endregion

    }
}