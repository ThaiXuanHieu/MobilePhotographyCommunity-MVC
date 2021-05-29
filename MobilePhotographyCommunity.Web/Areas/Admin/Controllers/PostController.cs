using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        // GET: Admin/Post
        public ActionResult Index(int? pageIndex, int pageSize = 5)
        {
            if (TempData["result"] != null)
            {
                ViewBag.Message = TempData["result"];
            }
            var postVms = postService.GetAllPostPaging(pageIndex, pageSize);
            ViewBag.PageNum = postService.GetAll().Count();
            return View(postVms);
        }

        public ActionResult Delete(int id)
        {
            postService.Delete(id);
            TempData["result"] = "Xóa thành công";
            return RedirectToAction("Index");
        }

        public ActionResult SortPost(int type, int? pageIndex, int pageSize = 5)
        {
            ViewBag.PageNum = postService.GetAll().Count();
            var postVms = new List<PostViewModel>();
            switch (type)
            {
                case 1:
                    postVms = postService.GetAllPostPaging(pageIndex, pageSize).OrderByDescending(x => int.Parse(x.Comments.Count().ToString()) + int.Parse(x.Likes.Count().ToString())).ToList();
                    return View("Index", postVms);
                case 2:
                    postVms = postService.GetAllPostPaging(pageIndex, pageSize).OrderBy(x => int.Parse(x.Comments.Count().ToString()) + int.Parse(x.Likes.Count().ToString())).ToList();
                    return View("Index", postVms);
                case 3:
                    postVms = postService.GetAllPostPaging(pageIndex, pageSize).OrderByDescending(x => x.CreatedTime).ToList();
                    return View("Index", postVms);
                case 4:
                    postVms = postService.GetAllPostPaging(pageIndex, pageSize).OrderBy(x => x.CreatedTime).ToList();
                    return View("Index", postVms);
                default:
                    postVms = postService.GetAllPostPaging(pageIndex, pageSize).ToList();
                    return View("Index", postVms);
            }
            
        }
    }
}