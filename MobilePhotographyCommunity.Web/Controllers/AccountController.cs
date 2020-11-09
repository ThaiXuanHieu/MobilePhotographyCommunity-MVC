using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IPostService postService;

        public AccountController(IUserService userService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
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
                    Session[UserSession.UserId] = user.UserId;
                    Session[UserSession.FullName] = user.FirstName + " " + user.LastName;
                    Session[UserSession.Avatar] = user.Avatar;
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
                    //var user = Mapper.Map<User>(model); if UserName not S then OK
                    User user = new User();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName_S;
                    user.PasswordHash = PasswordHashMD5.MD5Hash(model.Password_S);
                    user.DateOfBirth = DateTime.Now;
                    user.Gender = true;
                    user.Avatar = "AvatarDefault-Male.png";
                    userService.Add(user);

                    Session[UserSession.UserId] = userService.GetUser(model.UserName_S, PasswordHashMD5.MD5Hash(model.Password_S)).UserId;
                    Session[UserSession.FullName] = model.FirstName + " " + model.LastName;
                    Session[UserSession.Avatar] = userService.GetUser(model.UserName_S, PasswordHashMD5.MD5Hash(model.Password_S)).Avatar;
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

        //[ChildActionOnly]
        //public PartialViewResult LoginPartial()
        //{
        //    return PartialView("_LoginPartial");
        //}
        //[ChildActionOnly]
        //public PartialViewResult SignupPartial()
        //{
        //    return PartialView("_SignupPartial");
        //}

        public ActionResult UserProfile(int id)
        {
            var user = userService.GetById(id);
            var post = postService.GetByUserId(id);
            var userProfileVm = new UserProfileVm();
            userProfileVm.Users = user;
            userProfileVm.Posts = post;
            return View(userProfileVm);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }
    }
}