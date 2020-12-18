using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session["UserId"];
            if (sessions == null)
            {
                context.Result = new RedirectResult("/Account/Index");
            }
            base.OnActionExecuting(context);
        }
    }
}