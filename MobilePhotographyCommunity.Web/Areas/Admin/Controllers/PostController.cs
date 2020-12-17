using MobilePhotographyCommunity.Service;
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
    }
}