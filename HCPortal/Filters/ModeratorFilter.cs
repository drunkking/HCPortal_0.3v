using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HCPortal.Filters
{
    public class ModeratorFilter: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["ModeratorPrijavljen"] == null)
            {

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller","Auth"},
                    {"Action","LoginModerator"}

                    //TODO:
                    //najbolje da vratim 404 
                    // u mesto login forme, ne zanima me ko sta kuca u adress bar
                    // max sec, samo preko glavne strane i mog navodjenja moze da se 
                    //prijavi
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}