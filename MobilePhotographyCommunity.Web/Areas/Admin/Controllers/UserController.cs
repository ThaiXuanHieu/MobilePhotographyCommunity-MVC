using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Admin/User
        public ActionResult Index(int? pageIndex, int pageSize = 5)
        {
            if (TempData["result"] != null)
            {
                ViewBag.Message = TempData["result"];
            }
            var userVm = userService.GetAllPaging(pageIndex, pageSize);
            ViewBag.PageNum = userService.GetAll().Count();
            return View(userVm);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                userService.Delete(id);
                TempData["result"] = "Xóa thành công";
            }
            catch (Exception)
            {
                TempData["result"] = "Xóa thất bại";
            }
            return RedirectToAction("Index");
        }
    }
}