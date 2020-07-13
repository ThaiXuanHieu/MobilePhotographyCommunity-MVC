using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class FriendController : Controller
    {
        public FriendController()
        {

        }
        // GET: Friend
        public ActionResult Index()
        {
            return View();
        }
    }
}