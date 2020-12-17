using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using MobilePhotographyCommunity.Data.ViewModel;
using System;
using System.Collections.Generic;

namespace MobilePhotographyCommunity.Service
{
    public interface ICategoryService
    {
        IEnumerable<CategoryVm> GetCategories(int? pageIndex, int pageSize);
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        CategoryVm GetCategoryVm(int id);
        void Add(CategoryVm categoryVm);
        void Update(CategoryVm categoryVm);
        void Delete(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(CategoryVm categoryVm)
        {
            var category = new Category();
            category.CategoryName = categoryVm.CategoryName;
            category.Description = categoryVm.Description;
            category.CreatedBy = categoryVm.CreatedBy;
            category.CreatedTime = categoryVm.CreatedTime;
            category.MetaTitle = categoryVm.MetaTitle;
            categoryRepository.Add(category);
        }

        public void Update(CategoryVm categoryVm)
        {
            var category = categoryRepository.GetById(categoryVm.CategoryId);
            category.CategoryName = categoryVm.CategoryName;
            category.Description = categoryVm.Description;
            category.ModifiedBy = categoryVm.ModifiedBy;
            category.ModifiedTime = categoryVm.ModifiedTime;
            category.MetaTitle = categoryVm.MetaTitle;
            categoryRepository.Update(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public IEnumerable<CategoryVm> GetCategories(int? pageIndex, int pageSize)
        {
            var categories = categoryRepository.GetAllPaging(pageIndex, pageSize);
            var categoriesVm = new List<CategoryVm>();
            foreach(var item in categories)
            {
                var categoryVm = new CategoryVm();
                categoryVm.CategoryId = item.CategoryId;
                categoryVm.CategoryName = item.CategoryName;
                categoryVm.Description = item.Description;
                categoryVm.CreatedBy = item.CreatedBy;
                categoryVm.CreatedTime = item.CreatedTime;
                categoryVm.ModifiedBy = item.ModifiedBy;
                categoryVm.ModifiedTime = item.ModifiedTime;
                categoryVm.User = userRepository.GetById(Convert.ToInt32(item.CreatedBy));
                categoriesVm.Add(categoryVm);
            }

            return categoriesVm;
        }

        public CategoryVm GetCategoryVm(int id)
        {
            var category = categoryRepository.GetById(id);
            var categoryVm = new CategoryVm();
            categoryVm.CategoryId = category.CategoryId;
            categoryVm.CategoryName = category.CategoryName;
            categoryVm.Description = category.Description;
            categoryVm.CreatedBy = category.CreatedBy;
            categoryVm.CreatedTime = category.CreatedTime;
            return categoryVm;
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }
    }
}
