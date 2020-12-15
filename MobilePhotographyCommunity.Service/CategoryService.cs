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
        IEnumerable<CategoryVm> GetCategories();
        IEnumerable<Category> GetAll();
        Category GetById(int id);
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

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public IEnumerable<CategoryVm> GetCategories()
        {
            var categories = categoryRepository.GetAll();
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
    }
}
