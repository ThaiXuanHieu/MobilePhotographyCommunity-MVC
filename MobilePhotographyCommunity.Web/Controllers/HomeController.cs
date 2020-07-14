using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Index()
        {
            var posts = postService.GetAll();
            return View(posts);
        }

        
    }
}