using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        int CountByCategoryId(int id);
        IEnumerable<Post> GetByCategoryId(int id);
        IEnumerable<Post> GetAllPost();
        IEnumerable<Post> GetAllPostPaging(int? pageIndex, int pageSize);
        IEnumerable<Post> GetByUserId(int id);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public IEnumerable<Post> GetByCategoryId(int id)
        {
            return Context.Posts.Where(x => x.CategoryId == id).OrderByDescending(x => x.PostId);
        }

        public int CountByCategoryId(int id)
        {
            return Context.Posts.Where(x => x.CategoryId == id).Count();
        }

        public IEnumerable<Post> GetAllPost()
        {
            return Context.Posts.OrderByDescending(x => x.PostId).ToList();
        }

        public IEnumerable<Post> GetByUserId(int id)
        {
            return Context.Posts.Where(x => x.CreatedBy == id).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public IEnumerable<Post> GetAllPostPaging(int? pageIndex, int pageSize)
        {
            return Context.Posts.OrderByDescending(x => x.PostId).Skip(Convert.ToInt32(pageIndex) * pageSize).Take(pageSize).ToList();
        }
    }
}
