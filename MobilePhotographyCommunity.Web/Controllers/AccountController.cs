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
                    TempData["statusLogin"] = false;
                    TempData["messageLogin"] = "Tài khoản không tồn tại. Vui lòng kiểm tra lại.";
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(UserSignupModel model)
        {
            if (ModelState.IsValid)
            {
                var check = userService.CheckAccountExists(model.UserName_S);
                if(check)
                {
                    User user = new User();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName_S;
                    user.PasswordHash = PasswordHashMD5.MD5Hash(model.Password_S);
                    user.Gender = true;
                    user.Avatar = "AvatarDefault-Male.png";
                    userService.Add(user);

                    Session["UserId"] = userService.GetUser(model.UserName_S, PasswordHashMD5.MD5Hash(model.Password_S)).UserId;
                    Session["FullName"] = model.FirstName + " " + model.LastName;
                    return Redirect("/Home/Index");
                }
                else
                {
                    TempData["statusSignup"] = false;
                    TempData["messageSignup"] = "Tên đăng nhập đã tồn tại.Vui lòng kiểm tra lại.";
                }
            }
            return View("Index");
        }

        [ChildActionOnly]
        public PartialViewResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
        [ChildActionOnly]
        public PartialViewResult SignupPartial()
        {
            return PartialView("_SignupPartial");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }
    }
}