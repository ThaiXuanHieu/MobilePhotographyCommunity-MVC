using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }

        public PartialViewResult CategoryPartial()
        {
            var categories = categoryService.GetAll();
            List<PostCategoryViewModel> postCategoryViewModels = new List<PostCategoryViewModel>();
            foreach (var item in categories)
            {
                var postCategoryViewModel = new PostCategoryViewModel();
                postCategoryViewModel.CategoryId = item.CategoryId;
                postCategoryViewModel.CategoryName = item.CategoryName;
                postCategoryViewModel.Posts = postService.GetByCategoryId(item.CategoryId);
                postCategoryViewModels.Add(postCategoryViewModel);
            }

            return PartialView("_CategoryPartial", postCategoryViewModels);
        }

        public ActionResult Detail(int id)
        {
            PostCategoryViewModel postCategoryViewModel = new PostCategoryViewModel();
            postCategoryViewModel.CategoryId = id;
            postCategoryViewModel.CategoryName = categoryService.GetById(id).CategoryName;
            postCategoryViewModel.Posts = postService.GetByCategoryId(id);

            ViewBag.CategoryName = categoryService.GetById(id).CategoryName;
            return View(postCategoryViewModel);
        }
    }
}