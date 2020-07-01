using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Service;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginByCredentials(UserLoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = userService.GetUser(model.UserName, PasswordHashMD5.MD5Hash(model.Password));
                if(user == null)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại. Vui lòng kiểm tra lại.");
                }
                else
                {
                    Session["UserId"] = user.UserId;
                    Session["FullName"] = user.FirstName + " " + user.LastName;
                    return Redirect("/Home/Index");
                }
            }
            return View("Index");
        }
    }
}