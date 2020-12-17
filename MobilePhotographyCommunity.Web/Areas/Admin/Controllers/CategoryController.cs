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
        public ActionResult Index(int? pageIndex, int pageSize = 5)
        {
            if(TempData["result"] != null)
            {
                ViewBag.Message = TempData["result"];
            }

            var categoryVm = categoryService.GetCategories(pageIndex, pageSize);
            ViewBag.PageNum = categoryService.GetAll().Count();
            return View(categoryVm);
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
            TempData["result"] = "Thêm thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categoryVm = categoryService.GetCategoryVm(id);
            return View(categoryVm);
        }

        [HttpPost]
        public ActionResult Edit(CategoryVm categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }
            categoryVm.ModifiedBy = Convert.ToInt32(Session[UserSession.UserId]);
            categoryVm.ModifiedTime = DateTime.Now;
            categoryVm.MetaTitle = StringHelper.VNDecode(categoryVm.CategoryName);
            categoryService.Update(categoryVm);
            TempData["result"] = "Cập nhật thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            categoryService.Delete(id);
            TempData["result"] = "Xóa thành công";
            return RedirectToAction("Index");
        }
    }
}