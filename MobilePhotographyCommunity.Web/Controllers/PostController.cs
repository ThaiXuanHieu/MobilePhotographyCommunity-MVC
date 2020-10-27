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
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;

        public PostController(IPostService postService, IUserService userService, ICommentService commentService, ILikeService likeService)
        {
            this.postService = postService;
            this.userService = userService;
            this.commentService = commentService;
            this.likeService = likeService;
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
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

        public JsonResult LoadDetailPost(int postId)
        {
            bool status = true;
            var post = postService.GetById(postId);
            if (post == null)
            {
                status = false;
            }
            return Json(new { data = post, status = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePost(int postId)
        {
            bool status = false;
            try
            {
                postService.Delete(postId);
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }

            return Json(new { status = status });
        }

        public JsonResult ShowPost(int postId)
        {
            bool status = false;
            var postViewModel = new PostViewModel();
            try
            {
                var post = postService.GetById(postId);
                postViewModel = Mapper.Map<PostViewModel>(post);
                postViewModel.Comments = commentService.GetByPostId(postId);
                postViewModel.Likes = likeService.GetByPostId(postId);
                foreach (var j in postViewModel.Comments)
                {
                    // Commented by
                    j.User = userService.GetById(Convert.ToInt32(j.CreatedBy));
                }
                // Auth
                postViewModel.User = userService.GetById(Convert.ToInt32(post.CreatedBy));
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return Json(new { data = postViewModel, status = status }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LikePost(int postId)
        {
            bool stt = false;
            var likes = likeService.GetByPostId(postId);

            if (likes.Count() > 0)
            {
                var unlike = likes.Where(x => x.PostId == postId && x.CreatedBy == Convert.ToInt32(Session[UserSession.UserId])).FirstOrDefault();
                if (unlike != null)
                {
                    likeService.Delete(unlike);
                    stt = false;

                }
                else
                {
                    var like = new Like();
                    like.PostId = postId;
                    like.CreatedBy = Convert.ToInt32(Session[UserSession.UserId]);
                    likeService.Add(like);
                    stt = true;
                }
            }
            else
            {
                // first like
                var like = new Like();
                like.PostId = postId;
                like.CreatedBy = Convert.ToInt32(Session[UserSession.UserId]);
                likeService.Add(like);
                stt = true;
            }

            return Json(new { status = stt });

        }
    }
}