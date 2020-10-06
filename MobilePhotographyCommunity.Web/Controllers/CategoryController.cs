using AutoMapper;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;
        private readonly IUserService userService;

        public CategoryController(ICategoryService categoryService, IPostService postService,
            ICommentService commentService, ILikeService likeService, IUserService userService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.commentService = commentService;
            this.likeService = likeService;
            this.userService = userService;
        }

        public PartialViewResult CategoryPartial()
        {
            var categories = categoryService.GetAll();
            var postCategoryViewModels = new List<PostCategoryViewModel>();
            foreach (var item in categories)
            {
                var postCategoryViewModel = new PostCategoryViewModel();
                var postViewModels = new List<PostViewModel>();
                postCategoryViewModel.CategoryId = item.CategoryId;
                postCategoryViewModel.CategoryName = item.CategoryName;
                var posts = postService.GetByCategoryId(item.CategoryId);
                foreach(var i in posts)
                {
                    var postViewModel = new PostViewModel();
                    //postViewModel.PostId = i.PostId;
                    //postViewModel.CategoryId = i.CategoryId;
                    //postViewModel.Caption = i.Caption;
                    //postViewModel.Image = i.Image;
                    //postViewModel.CreatedBy = i.CreatedBy;
                    //postViewModel.CreatedTime = i.CreatedTime;
                    //postViewModel.Comments = i.Comments;
                    //postViewModel.Likes = i.Likes;
                    postViewModel = Mapper.Map<PostViewModel>(i);
                    //foreach (var j in postViewModel.Comments)
                    //{
                    //    j.User = userService.GetById(Convert.ToInt32(j.CreatedBy));
                    //}
                    postViewModel.User = userService.GetById(Convert.ToInt32(i.CreatedBy));
                    postViewModels.Add(postViewModel);
                }
                postCategoryViewModel.Posts = postViewModels;
                postCategoryViewModels.Add(postCategoryViewModel);
            }

            return PartialView("_CategoryPartial", postCategoryViewModels);
        }

        public ActionResult Detail(int id)
        {
            PostCategoryViewModel postCategoryViewModel = new PostCategoryViewModel();
            var postViewModels = new List<PostViewModel>();
            postCategoryViewModel.CategoryId = id;
            postCategoryViewModel.CategoryName = categoryService.GetById(id).CategoryName;
            var posts = postService.GetByCategoryId(id);
            foreach (var i in posts)
            {
                var postViewModel = new PostViewModel();
                //postViewModel.PostId = i.PostId;
                //postViewModel.CategoryId = i.CategoryId;
                //postViewModel.Caption = i.Caption;
                //postViewModel.Image = i.Image;
                //postViewModel.CreatedBy = i.CreatedBy;
                //postViewModel.CreatedTime = i.CreatedTime;
                //postViewModel.Comments = i.Comments;
                //postViewModel.Likes = i.Likes;
                postViewModel = Mapper.Map<PostViewModel>(i);
                foreach (var j in postViewModel.Comments)
                {
                    j.User = userService.GetById(Convert.ToInt32(j.CreatedBy));
                }
                foreach (var j in postViewModel.Likes)
                {
                    j.User = userService.GetById(Convert.ToInt32(j.CreatedBy));
                }
                postViewModel.User = userService.GetById(Convert.ToInt32(i.CreatedBy));
                postViewModels.Add(postViewModel);
            }
            postCategoryViewModel.Posts = postViewModels;
            return View(postCategoryViewModel);
        }

        public JsonResult SavePost()
        {
            int userId = (int)Session[UserSession.UserId];
            bool status = false;
            string fileName = "";
            if (Convert.ToInt32(Request.Form[0]) == 0)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase f = Request.Files[0];
                    fileName = Path.GetFileName(f.FileName);
                    //string folderPath = Server.MapPath("~/UploadFile/File/" + Foler + "/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath);
                    //}
                    //var path = Path.Combine(folderPath, fileName);
                    //f.SaveAs(path);
                    var path = Path.Combine(Server.MapPath("~/UploadImage/Photo/"), fileName);
                    f.SaveAs(path);
                }
                else
                {
                    status = false;
                }

                Post post = new Post();
                post.Caption = Request.Form[1];
                post.CategoryId = Convert.ToInt32(Request.Form[2]);
                post.Image = fileName;
                post.CreatedBy = userId;
                post.CreatedTime = DateTime.Now;

                try
                {
                    postService.Add(post);
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase f = Request.Files[0];
                    fileName = Path.GetFileName(f.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadImage/Photo/"), fileName);
                    f.SaveAs(path);
                }
                else
                {
                    fileName = postService.GetById(Convert.ToInt32(Request.Form[0])).Image;
                }

                Post post = postService.GetById(Convert.ToInt32(Request.Form[0]));
                post.Caption = Request.Form[1];
                post.CategoryId = Convert.ToInt32(Request.Form[2]);
                post.Image = fileName;
                post.CreatedBy = userId;
                post.CreatedTime = post.CreatedTime;
                post.ModifiedBy = userId;
                post.CreatedTime = DateTime.Now;

                try
                {
                    postService.Update(post);
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }

            return Json(new { status = status });
        }
    }
}