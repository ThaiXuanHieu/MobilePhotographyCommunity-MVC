using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IUserRoleService userRoleService;
        private readonly IRoleService roleService;

        public AccountController(IUserService userService, IPostService postService, IUserRoleService userRoleService,
            IRoleService roleService)
        {
            this.userService = userService;
            this.postService = postService;
            this.userRoleService = userRoleService;
            this.roleService = roleService;
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
            if (ModelState.IsValid)
            {
                User user = userService.GetUser(model.UserName, PasswordHashMD5.MD5Hash(model.Password));
                if (user == null)
                {
                    TempData["statusLogin"] = false;
                    TempData["messageLogin"] = "Tài khoản không tồn tại. Vui lòng kiểm tra lại.";
                }
                else
                {
                    var roles = userRoleService.GetByUserId(user.UserId);

                    Session[UserSession.UserId] = user.UserId;
                    Session[UserSession.FullName] = user.FirstName + " " + user.LastName;
                    Session[UserSession.Avatar] = user.Avatar;
                    Session[UserSession.Role] = roles;
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
                if (check)
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

                    var _user = userService.GetUser(model.UserName_S, PasswordHashMD5.MD5Hash(model.Password_S));
                    var userRole = new UserRole();
                    userRole.UserId = _user.UserId;
                    userRole.RoleId = roleService.GetByName(Common.Role.MEMBER).First().RoleId;
                    userRoleService.Add(userRole);
                    var roles = userRoleService.GetByUserId(_user.UserId);
                    Session[UserSession.UserId] = _user.UserId;
                    Session[UserSession.FullName] = model.FirstName + " " + model.LastName;
                    Session[UserSession.Avatar] = _user.Avatar;
                    Session[UserSession.Role] = roles;
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
            var userRole = userRoleService.GetByUserId(id);
            if (userRole.Count() > 1)
            {
                ViewBag.IsAdmin = true;
            }
            else
            {
                ViewBag.IsAdmin = false;
            }
            var post = postService.GetByUserId(id);
            var userProfileVm = new UserProfileVm();
            userProfileVm.Users = user;
            userProfileVm.Posts = post;
            return View(userProfileVm);
        }

        public ActionResult UpdateProfile(User model, HttpPostedFileBase file)
        {
            var user = userService.GetById(model.UserId);
            if (file == null)
            {
                user.Avatar = user.Avatar;
            }
            else
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/UploadImage/Avatar"), fileName);
                user.Avatar = fileName;
                file.SaveAs(path);
                Session[UserSession.Avatar] = fileName;

            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Gender = model.Gender;
            user.DateOfBirth = model.DateOfBirth;
            user.PhoneNumber = model.PhoneNumber;
            userService.Update(user);
            
            return RedirectToAction("UserProfile", new { id = user.UserId });
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}