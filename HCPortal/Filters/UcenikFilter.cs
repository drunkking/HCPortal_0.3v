using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HCPortal.Filters
{
    public class UcenikFilter: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UcenikPrijavljen"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller","Auth"},
                    {"Action","LoginUcenik"}
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}