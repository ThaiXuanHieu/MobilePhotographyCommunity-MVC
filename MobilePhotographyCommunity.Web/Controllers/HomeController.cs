using AutoMapper;
using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;

        public HomeController(IPostService postService, IUserService userService, ICommentService commentService, ILikeService likeService)
        {
            this.postService = postService;
            this.userService = userService;
            this.commentService = commentService;
            this.likeService = likeService;
        }

        public ActionResult Index()
        {
            var postViewModels = new List<PostViewModel>();
            var posts = postService.GetAllPost();
            foreach (var i in posts)
            {
                var postViewModel = new PostViewModel();
                //postViewModel.PostId = i.PostId;
                //postViewModel.CategoryId = i.CategoryId;
                //postViewModel.Caption = i.Caption;
                //postViewModel.Image = i.Image;
                //postViewModel.CreatedBy = i.CreatedBy;
                //postViewModel.CreatedTime = i.CreatedTime;
                postViewModel = Mapper.Map<PostViewModel>(i);
                foreach(var j in postViewModel.Comments)
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
            return View(postViewModels);
        }

        
    }
}