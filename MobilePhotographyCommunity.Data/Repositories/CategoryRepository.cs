using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllPaging(int? pageIndex, int pageSize);
        IEnumerable<Category> GetByStatus();
        IEnumerable<Category> Search(string str);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public IEnumerable<Category> GetAllPaging(int? pageIndex, int pageSize)
        {
            return Context.Categories.OrderByDescending(x => x.CategoryId).Skip(Convert.ToInt32(pageIndex) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Category> GetByStatus()
        {
            return Context.Categories.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Category> Search(string str)
        {
            return Context.Categories.Where(x => x.CategoryName.Contains(str)).ToList();
        }
    }
}
