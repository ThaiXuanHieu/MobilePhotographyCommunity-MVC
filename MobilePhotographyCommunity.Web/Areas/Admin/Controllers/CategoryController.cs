using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.ViewModel;
using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(categoryService.GetCategories());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryVm categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }
            categoryVm.CreatedBy = Convert.ToInt32(Session[UserSession.UserId]);
            categoryVm.CreatedTime = DateTime.Now;
            categoryVm.MetaTitle = StringHelper.VNDecode(categoryVm.CategoryName);
            categoryService.Add(categoryVm);
            return RedirectToAction("Index");
        }
    }
}