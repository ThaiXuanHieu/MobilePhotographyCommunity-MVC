using MobilePhotographyCommunity.Data.DomainModel;
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
        private readonly IUserRoleService userRoleService;

        public UserController(IUserService userService, IUserRoleService userRoleService)
        {
            this.userService = userService;
            this.userRoleService = userRoleService;
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

        public ActionResult Search(string str)
        {
            ViewBag.SearchString = str;
            var users = userService.Search(str);
            return View("Index", users);
        }

        public ActionResult AssignRole(int id)
        {
            var user = userService.GetById(id);
            var userRole = new UserRole();
            userRole.UserId = id;
            userRole.RoleId = 1;
            userRoleService.Add(userRole);
            TempData["result"] = "Gán quyền thành công";
            return RedirectToAction("Index");
        }
    }
}