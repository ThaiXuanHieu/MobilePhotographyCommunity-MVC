using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        int CountByCategoryId(int id);
        IEnumerable<Post> GetByCategoryId(int id);
        IEnumerable<Post> GetAllPost();
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public IEnumerable<Post> GetByCategoryId(int id)
        {
            return Context.Posts.Where(x => x.CategoryId == id);
        }

        public int CountByCategoryId(int id)
        {
            return Context.Posts.Where(x => x.CategoryId == id).Count();
        }

        public IEnumerable<Post> GetAllPost()
        {
            return Context.Posts.OrderByDescending(x => x.PostId).ToList();
        }
    }
}
