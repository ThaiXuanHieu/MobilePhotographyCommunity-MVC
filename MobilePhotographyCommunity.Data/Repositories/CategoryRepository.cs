using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllPaging(int? pageIndex, int pageSize);
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
    }
}
